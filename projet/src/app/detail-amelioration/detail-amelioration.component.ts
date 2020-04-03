import { Component, OnInit } from '@angular/core';
import { AmeliorationService } from '../Services/amelioration.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-detail-amelioration',
  templateUrl: './detail-amelioration.component.html',
  providers: [AmeliorationService],
  styleUrls: ['./detail-amelioration.component.css']
})
export class DetailameliorationComponent implements OnInit {

  ameliorations:any;
  
  constructor(private route: ActivatedRoute,
    private ameliorationsService: AmeliorationService) {
     }

     ngOnInit(): void {
      let id = this.route.snapshot.paramMap.get('Id');
        this.route.paramMap.subscribe(params => {
        this.ameliorations = this.ameliorationsService.getAmeliorationById(id);
        console.log(this.ameliorations);
      });
    }
}
