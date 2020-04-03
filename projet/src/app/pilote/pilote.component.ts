import { Component, OnInit } from '@angular/core';
import { Pilote } from '../Models/pilote';
import { PiloteService } from '../Services/pilote.service';

@Component({
  selector: 'app-pilote',
  templateUrl: './pilote.component.html',
  providers: [Pilote],
  styleUrls: ['./pilote.component.css']
})
export class PiloteComponent implements OnInit {

  pilotes: Pilote[];
  constructor(private piloteService: PiloteService) { }

  ngOnInit(): void {
    this.getPilotes();
  }

  getPilotes(): void {
    this.piloteService.getPilotes()
      .subscribe(heroes => (this.pilotes = heroes));
  }


  getPiloteById(id: any) {
    this.piloteService.getPiloteById(id)
      .subscribe(data => {
        this.pilotes = data
        console.log(data);
      });
  }
}
