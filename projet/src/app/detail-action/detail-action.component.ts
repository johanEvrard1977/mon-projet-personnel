import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ActionService } from '../Services/action.service'
import { trigger, state, style, transition, animate } from '@angular/animations';
import { slideInAnimation } from '../Models/slide-in-animation';
import { transform } from 'typescript';
@Component({
  selector: 'app-detail-action',
  templateUrl: './detail-action.component.html',
  providers: [ActionService],
  styleUrls: ['./detail-action.component.css'],
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
export class DetailActionComponent implements OnInit {

  
  actions:any;

  constructor(private route: ActivatedRoute,
    private actionService: ActionService) {
     }

     ngOnInit(): void {
     let id = this.route.snapshot.paramMap.get('Id');
     this.actionService.getActionById(id).subscribe(Action => this.actions = Action) 
    }

    isOpen = true;

  toggle() {
    this.isOpen = !this.isOpen;
  }
    
}