import { Component, OnInit } from '@angular/core';
import { AmeliorationService } from '../Services/amelioration.service';
import { ActivatedRoute } from '@angular/router';
import { slideInAnimation } from '../Models/slide-in-animation';
import { trigger, state, style, transition, animate } from '@angular/animations';

@Component({
  selector: 'app-detail-amelioration',
  templateUrl: './detail-amelioration.component.html',
  providers: [AmeliorationService],
  styleUrls: ['./detail-amelioration.component.css'],
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
export class DetailameliorationComponent implements OnInit {

  ameliorations:any;
  
  constructor(private route: ActivatedRoute,
    private ameliorationsService: AmeliorationService) {
     }

     ngOnInit(): void {
      let id = this.route.snapshot.paramMap.get('Id');
     this.ameliorationsService.getAmeliorationById(id).subscribe(amelioration => this.ameliorations = amelioration); 
    }

    isOpen = true;

  toggle() {
    this.isOpen = !this.isOpen;
  }
}