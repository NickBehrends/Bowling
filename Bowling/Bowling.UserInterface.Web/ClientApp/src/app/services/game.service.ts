import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Game } from '../interfaces/Game';

@Injectable({
  providedIn: 'root'
})
export class GameService {
  apiBase = environment.apiBase;

  constructor(private http: HttpClient) { }

  createGame(body: {}): Observable<any> {
    return this.http.post(`${this.apiBase}api/Commands/CreateGame`, body);
  }

  throwBall(body: {}): Observable<any> {
    return this.http.post(`${this.apiBase}api/Commands/ThrowBall`, body);
  }

  getCurrentGame(): Observable<any> {
    const options = {
      observe: 'body' as const,
      responseType: 'json' as const,
    };

    return this.http.get<Game>(`${this.apiBase}api/Queries/GetCurrentGame`, options);
  }

  isThereAnActiveGame(): Observable<any> {
    const options = {
      observe: 'body' as const,
      responseType: 'json' as const,
    };

    return this.http.get<any>(`${this.apiBase}api/Queries/IsThereAnActiveGame`, options);
  }

  whosTurnIsIt(): Observable<any> {
    const options = {
      observe: 'body' as const,
      //responseType: 'json' as const,
      responseType: 'application/json' as const,
    };

    return this.http.get<any>(`${this.apiBase}api/Queries/WhosTurnIsIt`, options);
  }
}
