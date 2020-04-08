import { Component, OnInit } from '@angular/core';
import { ActionService } from '../Services/action.service';
import { actions } from '../Models/actions';

@Component({
  selector: 'app-action',
  templateUrl: './action.component.html',
  providers: [actions],
  styleUrls: ['./action.component.css'],
})
export class ActionComponent implements OnInit {

  actions: actions[];

  constructor(private actionService: ActionService) { 
    
  }

  ngOnInit(): void {
    this.getActions();
  }

  getActions(): void {
    this.actionService.getActions()
      .subscribe(heroes => (this.actions = heroes));
  }


  getActionById(id: any) {
    this.actionService.getActionById(id)
      .subscribe(data => {
        this.actions = data
      });
  }
}
