import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { VaisseauService } from '../Services/vaisseau.service';

@Component({
  selector: 'app-detail-vaisseau',
  templateUrl: './detail-vaisseau.component.html',
  providers: [VaisseauService],
  styleUrls: ['./detail-vaisseau.component.css']
})
export class DetailVaisseauComponent implements OnInit {

  vaisseaux;
  
  constructor(private route: ActivatedRoute,
    private vaisseauxService: VaisseauService) {
     }

     ngOnInit(): void {
      let id = this.route.snapshot.paramMap.get('Id');
        this.route.paramMap.subscribe(params => {
        this.vaisseaux = this.vaisseauxService.getVaisseauById(id);
      });
    }

}
