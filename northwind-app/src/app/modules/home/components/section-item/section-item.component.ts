import { Component, Input, OnInit } from '@angular/core';
import { Section } from '../../../../core/models/Section';

@Component({
  selector: 'app-section-item',
  templateUrl: './section-item.component.html',
  styleUrls: ['./section-item.component.css']
})
export class SectionItemComponent implements OnInit {

  @Input() section: Section = {
    name: '',
    text: '',
    icon: '',
    router: ['']
  }

  constructor() { }

  ngOnInit(): void {
  }

}
