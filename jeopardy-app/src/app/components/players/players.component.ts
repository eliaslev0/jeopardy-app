import { Component, OnInit } from '@angular/core';
import * as $ from "jquery";
import { MainPageComponent } from '../main-page/main-page.component';

@Component({
  selector: 'app-players',
  templateUrl: './players.component.html',
  styleUrls: ['./players.component.scss']
})
export class PlayersComponent implements OnInit {

  playerCount: number = 0;

  team1Points: number = 0;
  team2Points: number = 0;
  team3Points: number = 0;
  
  constructor() { }

  ngOnInit(): void {
    
  }

  setPlayers(numSelected: number) {
    this.playerCount = numSelected;
    console.log(this.playerCount);
  }

  loadPlayers() {
      document.getElementById('setTeamsButton')!.style.display = 'none';
      document.getElementById('teamcard1')!.style.display = 'inline-block';
      if (this.playerCount > 1) {
        document.getElementById('teamcard2')!.style.display = 'inline-block';
      }
      if (this.playerCount > 2) {
        document.getElementById('teamcard3')!.style.display = 'inline-block';
      }

      console.log("test");
  }

  subtractPoints1() {
    this.team1Points -= MainPageComponent.pointSelected;
    if (MainPageComponent.count == 30) {
      if (this.team1Points > this.team2Points && this.team1Points > this.team3Points)
        alert("team 1 wins");
      else if (this.team2Points > this.team1Points && this.team2Points > this.team3Points)
        alert("team 2 wins");
      else if (this.team3Points > this.team1Points && this.team3Points > this.team2Points)
        alert("team 3 wins");
      else
        ("there was a tie");
    }
  }

  addPoints1() {
    this.team1Points += MainPageComponent.pointSelected;
    if (MainPageComponent.count == 30) {
      if (this.team1Points > this.team2Points && this.team1Points > this.team3Points)
        alert("team 1 wins");
      else if (this.team2Points > this.team1Points && this.team2Points > this.team3Points)
        alert("team 2 wins");
      else if (this.team3Points > this.team1Points && this.team3Points > this.team2Points)
        alert("team 3 wins");
      else
        ("there was a tie");
    }
  }

  subtractPoints2() {
    this.team2Points -= MainPageComponent.pointSelected;
    if (MainPageComponent.count == 30) {
      if (this.team1Points > this.team2Points && this.team1Points > this.team3Points)
        alert("team 1 wins");
      else if (this.team2Points > this.team1Points && this.team2Points > this.team3Points)
        alert("team 2 wins");
      else if (this.team3Points > this.team1Points && this.team3Points > this.team2Points)
        alert("team 3 wins");
      else
        ("there was a tie");
    }
  }

  addPoints2() {
    this.team2Points += MainPageComponent.pointSelected;
    if (MainPageComponent.count == 30) {
      if (this.team1Points > this.team2Points && this.team1Points > this.team3Points)
        alert("team 1 wins");
      else if (this.team2Points > this.team1Points && this.team2Points > this.team3Points)
        alert("team 2 wins");
      else if (this.team3Points > this.team1Points && this.team3Points > this.team2Points)
        alert("team 3 wins");
      else
        ("there was a tie");
    }
  }

  subtractPoints3() {
    this.team3Points -= MainPageComponent.pointSelected;
    if (MainPageComponent.count == 30) {
      if (this.team1Points > this.team2Points && this.team1Points > this.team3Points)
        alert("team 1 wins");
      else if (this.team2Points > this.team1Points && this.team2Points > this.team3Points)
        alert("team 2 wins");
      else if (this.team3Points > this.team1Points && this.team3Points > this.team2Points)
        alert("team 3 wins");
      else
        ("there was a tie");
    }
  }

  addPoints3() {
    this.team3Points += MainPageComponent.pointSelected;
    if (MainPageComponent.count == 30) {
      if (this.team1Points > this.team2Points && this.team1Points > this.team3Points)
        alert("team 1 wins");
      else if (this.team2Points > this.team1Points && this.team2Points > this.team3Points)
        alert("team 2 wins");
      else if (this.team3Points > this.team1Points && this.team3Points > this.team2Points)
        alert("team 3 wins");
      else
        ("there was a tie");
    }
  }


}
