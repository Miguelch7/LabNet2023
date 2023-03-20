import {
  SCORE_INICIO,
  HIGH_SCORE,
  RANGO_NUMEROS
} from './utils/constants.js';

import {
  body,
  btnReiniciar,
  btnSumbit,
  spanHighScore,
  spanScore,
  inputNumero,
  pNumeroOculto,
  pResultado,
  pMensaje,
  form,
  h2Intervalos
} from './selectores.js';

import {
  esValido
} from './utils/functions.js';

export default class App {
  score = SCORE_INICIO;
  highScore = HIGH_SCORE;
  rangoNumeros = {
    min: RANGO_NUMEROS.min,
    max: RANGO_NUMEROS.max
  }
  numeroAleatorio = 0;

  constructor() {
    this.initApp();
  }

  initApp() {
    this.reestablecerValores();

    form.addEventListener('submit', e => this.formSubmit(e));

    btnReiniciar.addEventListener('click', e => this.reestablecerValores());
  }

  formSubmit(e) {
    e.preventDefault();

    const numero = parseInt(e.target[0].value);
    if (numero) {
      this.validarNumero(numero);
    }
  }

  reestablecerValores() {
    this.score = SCORE_INICIO;
    spanScore.textContent = this.score;

    this.highScore = localStorage.getItem('high-score') || this.highScore;
    spanHighScore.textContent = this.highScore;
    
    h2Intervalos.textContent = `(entre ${this.rangoNumeros.min} y ${this.rangoNumeros.max})`;
    
    this.numeroAleatorio = Math.floor((Math.random() * this.rangoNumeros.max) + this.rangoNumeros.min);
    pNumeroOculto.textContent = '?';

    body.classList.remove('background');
    pResultado.textContent = 'Resultado';
    
    this.ocultarMensajeError();
    this.activarBtnSubmit();
    this.limpiarInput();
  }

  validarNumero(num) {
    if (!esValido(num, this.rangoNumeros.min, this.rangoNumeros.max)) {
      this.mostrarMensajeError();
      return;
    }
  
    this.ocultarMensajeError();

    this.compararNumero(num);
  }

  compararNumero(num) {
    if (num == this.numeroAleatorio) {
      return this.mostarResultadoGanador(num);
    }

    let mensaje = '';

    if (num > this.numeroAleatorio) {
      mensaje = 'Muy Alto!';
    }
  
    if (num < this.numeroAleatorio) {
      mensaje = 'Muy Bajo!';
    }

    pResultado.textContent = mensaje;
    this.score--;
    spanScore.textContent = this.score;

    if (this.score == 0) {
      this.mostarResultadoPerdedor();
    }
  
    this.limpiarInput();
  }

  mostrarMensajeError() {
    pMensaje.textContent = `Debes ingresar un número del ${this.rangoNumeros.min} al ${this.rangoNumeros.max}`;
    pMensaje.classList.remove("hidden");
  }

  ocultarMensajeError() {
    pMensaje.textContent = "";
    pMensaje.classList.add("hidden");
  }

  mostrarNumeroOculto() {
    pNumeroOculto.textContent = this.numeroAleatorio;
  }

  limpiarInput() {
    inputNumero.value = '';
  }

  mostarResultadoGanador() {
    if (this.score > this.highScore) {
      localStorage.setItem('high-score', this.score);
      this.highScore = this.score;
    }

    pResultado.textContent = 'Ganaste!';
    this.mostrarNumeroOculto();
    this.desactivarBtnSubmit();
    body.classList.add('background');
  }

  mostarResultadoPerdedor() {
    pResultado.textContent = 'Perdiste! :c';
    this.mostrarNumeroOculto();
    this.desactivarBtnSubmit();
    body.classList.add('background-red');
  }

  activarBtnSubmit() {
    btnSumbit.removeAttribute('disabled');
  }

  desactivarBtnSubmit() {
    btnSumbit.setAttribute('disabled', true);
  }
}