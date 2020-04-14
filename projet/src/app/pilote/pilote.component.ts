import { Component, OnInit } from '@angular/core';
import { Pilote } from '../Models/pilote';
import { PiloteService } from '../Services/pilote.service';
import { slideInAnimation } from '../Models/slide-in-animation';
import { trigger, state, style, transition, animate } from '@angular/animations';

@Component({
  selector: 'app-pilote',
  templateUrl: './pilote.component.html',
  providers: [Pilote],
  styleUrls: ['./pilote.component.css'],
  animations: [
    slideInAnimation,
    // animation triggers go here
  
    trigger('openClose', [
      state('open', style({
        width: '550px',
        opacity: 1,
        backgroundColor: 'black'
      })),
      state('closed', style({
        opacity: 0,
        backgroundColor: 'red'
      })),
      transition('* => *', [
        animate('0.5s')
      ]),
      ]),
  ],
})
export class PiloteComponent implements OnInit {

  pilotes: Pilote[];
  compteur: number;
  compteur2:number;
  isOpen = true;
  constructor(private piloteService: PiloteService) { }

  ngOnInit(): void {
    this.getPilotes();
    this.compteur = 0;
    this.compteur2 = 12;
  }

  getPilotes(): void {
    this.piloteService.getPilotes()
      .subscribe(heroes => (this.pilotes = heroes));
  }


  getPiloteById(id: any) {
    this.piloteService.getPiloteById(id)
      .subscribe(data => {
        this.pilotes = data
        console.log(data);
      });
  }

  next(){
    this.compteur += 12;
    this.compteur2 +=12;
  }
  before(){
    this.compteur -= 12;
    this.compteur2 -=12;
  }
}
