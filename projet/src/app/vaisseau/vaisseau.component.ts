import { Component, OnInit } from '@angular/core';
import { VaisseauService } from '../Services/vaisseau.service';
import { Vaisseau } from '../Models/vaisseau';

@Component({
  selector: 'app-vaisseau',
  templateUrl: './vaisseau.component.html',
  providers: [Vaisseau],
  styleUrls: ['./vaisseau.component.css']
})
export class VaisseauComponent implements OnInit {

  vaisseau: Vaisseau[];

  constructor(private vaisseauService: VaisseauService) { }

  ngOnInit(): void {
    this.getVaisseaux();
  }

  getVaisseaux(): void {
    this.vaisseauService.getVaisseaux()
      .subscribe(heroes => (this.vaisseau = heroes));
  }


  getVaisseauById(id: any) {
    this.vaisseauService.getVaisseauById(id)
      .subscribe(data => {
        this.vaisseau = data
        console.log(data);
      });
  }

}
