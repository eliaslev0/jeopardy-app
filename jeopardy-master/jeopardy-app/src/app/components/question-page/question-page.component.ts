import { Component, OnInit } from '@angular/core';
import { Clue } from 'src/app/models/clue';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-question-page',
  templateUrl: './question-page.component.html',
  styleUrls: ['./question-page.component.scss']
})
export class QuestionPageComponent implements OnInit {

  constructor(private service: ApiService) {
    console.log("test");
   }

  public clue = new Clue();

  ngOnInit(): void {
    this.service.updateClue(this.clue.Id!, this.clue).subscribe((result: any) => {
      
    })
  }

}
