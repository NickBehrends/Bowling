import { Component } from '@angular/core';
import { GameService } from '../services/game.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  constructor(private service: GameService) { }

  ngOnInit() {
    this.service.isThereAnActiveGame().subscribe(
      (data) => {
        if (data) {
          this.gameInProgress = true;
        }
      },
      (error) => console.log("error", error)
    );
  }

  gameInProgress = false;

  gameStarted(gameId) {
    this.gameInProgress = true;
  }
}
