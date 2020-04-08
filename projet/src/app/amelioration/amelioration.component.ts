import { Component, OnInit } from '@angular/core';
import { Amelioration } from '../Models/amelioration';
import { AmeliorationService } from '../Services/amelioration.service'

@Component({
  selector: 'app-amelioration',
  templateUrl: './amelioration.component.html',
  providers: [Amelioration],
  styleUrls: ['./amelioration.component.css']
})
export class AmeliorationComponent implements OnInit {

  ameliorations: Amelioration[];
  constructor(private ameliorationService:AmeliorationService) { }

  ngOnInit(): void {
    this.getAmeliorations();
  }

  getAmeliorations(): void {
    this.ameliorationService.getAmeliorations()
      .subscribe(heroes => (this.ameliorations = heroes));
  }


  getAmeliorationById(id: any) {
    this.ameliorationService.getAmeliorationById(id)
      .subscribe(data => {
        this.ameliorations = data
      });
  
  }
}
