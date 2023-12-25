import { Component, OnInit } from '@angular/core';
import { SelectControlValueAccessor } from '@angular/forms';
import { elementAt } from 'rxjs';
import { Clue } from 'src/app/models/clue';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.scss']
})
export class MainPageComponent implements OnInit {

  rows = [ 1, 2, 3, 4, 5 ];
  categories: Array<string> = new Array<string>;

  public clue = new Clue();

  public isQuestion: boolean = false;
  public isAnswer: boolean = false;

  public static count: number = 0;
  public static pointSelected = 0;

  constructor(private service: ApiService) { 
  }

  a: any;
  b: any;
  c: any;
  d: any;
  e: any;
  f: any;

  getCategories() {
    
    this.service.getClue((Math.floor(Math.random() * (1000 - 1 + 1)) + 1)).subscribe((result: any) => {
      this.categories.push(result.Category)     
    });
    this.service.getClue((Math.floor(Math.random() * (1000 - 1 + 1)) + 1)).subscribe((result: any) => {
      this.categories.push(result.Category)     
    });   
    this.service.getClue((Math.floor(Math.random() * (1000 - 1 + 1)) + 1)).subscribe((result: any) => {
      this.categories.push(result.Category)     
    });
    this.service.getClue((Math.floor(Math.random() * (1000 - 1 + 1)) + 1)).subscribe((result: any) => {
      this.categories.push(result.Category)     
    });
    this.service.getClue((Math.floor(Math.random() * (1000 - 1 + 1)) + 1)).subscribe((result: any) => {
      this.categories.push(result.Category)     
    });
    this.service.getClue((Math.floor(Math.random() * (1000 - 1 + 1)) + 1)).subscribe((result: any) => {
      this.categories.push(result.Category)     
    });
    
  }

  
  

  ngOnInit(): void {
    this.getCategories();

    
    // this.service.getClue(456).subscribe((result: any) => {
    //   this.clue = result;
    // });
    
  }

  updateClue() {
    this.service.updateClue(this.clue.id!, this.clue).subscribe((result: any) => {
      
    })
  }

  setText(element: any, value: number, category: string) {
    console.log(category, value);
    
      this.service.getClueByCategoryAndValue(category, value * 100).subscribe((result: Clue) => {
        this.clue = result;
        console.log(this.clue);
        if(!this.isQuestion && !this.isAnswer && element.style.opacity != 0.2) {
          element.textContent = this.clue.question;
          
          this.isQuestion = true;
        }
        else if (this.isQuestion && !this.isAnswer && element.style.opacity != 0.2) {
          element.textContent = this.clue.answer;
          this.isAnswer = true;
          this.isQuestion = false;
    
        }
        else {
          element.textContent = value * 100;
          if (element.style.opacity != 0.2)
            MainPageComponent.count++;
          element.style.opacity = 0.2;
          console.log(MainPageComponent.count);
          this.isQuestion = false;
          this.isAnswer = false;
        }
        MainPageComponent.pointSelected = value * 100;
  
      }
      , (error) => {
        if (element.style.opacity != 0.2)
            MainPageComponent.count++;
        element.style.opacity = 0.2;
        console.log(MainPageComponent.count);
      });
      if (MainPageComponent.count == 30)
        console.log("game over");
  }
  

}
