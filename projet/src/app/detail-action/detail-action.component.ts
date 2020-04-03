import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ActionService } from '../Services/action.service'
@Component({
  selector: 'app-detail-action',
  templateUrl: './detail-action.component.html',
  providers: [ActionService],
  styleUrls: ['./detail-action.component.css']
})
export class DetailActionComponent implements OnInit {
  actions:any;
  constructor(private route: ActivatedRoute,
    private actionService: ActionService) {
     }

     ngOnInit(): void {
      let id = this.route.snapshot.paramMap.get('Id');
        this.route.paramMap.subscribe(params => {
        this.actions = this.actionService.getActionById(id);
        console.log(id);
      });
    }
}
