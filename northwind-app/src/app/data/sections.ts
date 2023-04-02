import { Section } from '../core/models/Section';

const sections: Section[] = [
  {
    name: 'Categorías',
    text: 'Cree, liste, edite y elimine todas las categorías de Northwind.',
    icon: 'category',
    router: ['/', 'categories']
  },
  {
    name: 'Proveedores',
    text: 'Cree, liste, edite y elimine todos los proveedores de Northwind.',
    icon: 'groups',
    router: ['/', 'suppliers']
  }
]

export default sections;