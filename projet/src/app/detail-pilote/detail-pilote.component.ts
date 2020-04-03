import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PiloteService } from '../Services/pilote.service';

@Component({
  selector: 'app-detail-pilote',
  templateUrl: './detail-pilote.component.html',
  styleUrls: ['./detail-pilote.component.css']
})
export class DetailPiloteComponent implements OnInit {

  pilotes:any;
  constructor(private route: ActivatedRoute,
    private piloteService: PiloteService) {
     }

     ngOnInit(): void {
      let id = this.route.snapshot.paramMap.get('Id');
        this.route.paramMap.subscribe(params => {
        this.pilotes = this.piloteService.getPiloteById(id);
        console.log(id);
      });
    }

}
