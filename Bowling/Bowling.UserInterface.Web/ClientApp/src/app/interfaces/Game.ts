export interface Game {
  id: string,
  name: string,
  players: Array<Player>;
}

export interface Player {
  name: string
}
