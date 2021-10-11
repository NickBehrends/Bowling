import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormBuilder, Validators, FormArray } from '@angular/forms';
import { GameService } from '../services/game.service';

@Component({
  selector: 'app-start-game',
  templateUrl: './start-game.component.html',
  styleUrls: ['./start-game.component.css']
})

export class StartGameComponent implements OnInit {
  constructor(private fb: FormBuilder, private service: GameService) { }

  ngOnInit() {
  }

  @Output() gameCreatedEvent = new EventEmitter<string>();

  gameForm = this.fb.group({
    gameName: ['', Validators.required],
    players: this.fb.array([
      this.fb.control('', Validators.required)
    ])
  });

  get players() {
    return this.gameForm.get('players') as FormArray;
  }

  addPlayer() {
    this.players.push(this.fb.control('', Validators.required));
  }

  canSubmit() {
    if (!this.gameForm.valid)
      return false;
  }

  startGame() {
    this.service.createGame(this.gameForm.value).subscribe((gameId) => {
      this.gameCreatedEvent.emit(gameId);
    })
  }
}
