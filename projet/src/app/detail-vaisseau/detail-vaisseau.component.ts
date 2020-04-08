import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { VaisseauService } from '../Services/vaisseau.service';
import { slideInAnimation } from '../Models/slide-in-animation';
import { trigger, state, style, transition, animate } from '@angular/animations';

@Component({
  selector: 'app-detail-vaisseau',
  templateUrl: './detail-vaisseau.component.html',
  providers: [VaisseauService],
  styleUrls: ['./detail-vaisseau.component.css'],
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
export class DetailVaisseauComponent implements OnInit {

  vaisseaux;
  
  constructor(private route: ActivatedRoute,
    private vaisseauxService: VaisseauService) {
     }

     ngOnInit(): void {
      let id = this.route.snapshot.paramMap.get('Id');
     this.vaisseauxService.getVaisseauById(id).subscribe(Action => this.vaisseaux = Action) 
    }
    isOpen = true;

    toggle() {
      this.isOpen = !this.isOpen;
    }
}
