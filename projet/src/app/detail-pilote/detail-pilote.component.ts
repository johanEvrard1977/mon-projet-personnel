import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PiloteService } from '../Services/pilote.service';
import { slideInAnimation } from '../Models/slide-in-animation';
import { trigger, state, style, transition, animate } from '@angular/animations';

@Component({
  selector: 'app-detail-pilote',
  templateUrl: './detail-pilote.component.html',
  providers: [PiloteService],
  styleUrls: ['./detail-pilote.component.css'],
  animations: [
    slideInAnimation,
    // animation triggers go here
  
    trigger('openClose', [
      state('open', style({
        width: '250px',
        opacity: 1,
        backgroundColor: 'red'
      })),
      state('closed', style({
        opacity: 0,
        backgroundColor: 'pink'
      })),
      transition('* => *', [
        animate('0.7s')
      ]),
      ]),
  ],
})
export class DetailPiloteComponent implements OnInit {

  pilotes:any;
  constructor(private route: ActivatedRoute,
    private piloteService: PiloteService) {
     }

     ngOnInit(): void {
      let id = this.route.snapshot.paramMap.get('Id');
     this.piloteService.getPiloteById(id).subscribe(Pilote => this.pilotes = Pilote) 
    }

    isOpen = true;

  toggle() {
    this.isOpen = !this.isOpen;
  }
}
