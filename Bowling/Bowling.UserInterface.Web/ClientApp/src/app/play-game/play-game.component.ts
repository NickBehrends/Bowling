import { Component, OnInit } from '@angular/core';
import { GameService } from "../services/game.service";
import { Game } from "../interfaces/Game";

@Component({
  selector: 'app-play-game',
  templateUrl: './play-game.component.html',
  styleUrls: ['./play-game.component.css']
})
export class PlayGameComponent implements OnInit {

  constructor(private service: GameService) { }

  ngOnInit() {
    this.refreshScoreCard();
    this.whosTurnIsIt();
  }

  currentPlayer = "";
  currentGame: Game;
  roll = 0;

  whosTurnIsIt() {
    this.service.whosTurnIsIt().subscribe(
      (data) => {
        console.log(data);
        this.currentPlayer = data;
      },
      (error) => console.log("error", error)
    );
  }

  refreshScoreCard() {
    this.service.getCurrentGame().subscribe((game) => {
      console.log("game", game);
      this.currentGame = game;
    });
  }

  throwTheBall() {
    this.roll = Math.floor(Math.random() * 9) + 1;
    this.service.throwBall({
      player: this.currentPlayer,
      pins: this.roll
    }).subscribe((response) => {
      this.refreshScoreCard();
      this.whosTurnIsIt();
    });
  }
}
