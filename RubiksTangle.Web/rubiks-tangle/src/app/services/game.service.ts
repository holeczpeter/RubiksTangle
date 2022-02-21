import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { PictureModel } from '../models/picture-model';
import { Observable } from 'rxjs';
import { SolutionStep } from '../models/solution-step';
@Injectable({
  providedIn: 'root'
})
export class GameService {

  constructor(private readonly httpClient: HttpClient) { }

  cardShuffle(): Observable<boolean> {
    return this.httpClient.post<boolean>('Game/CardShuffle', null);
  }

  getPictures(): Observable<Array<PictureModel>> {
    return this.httpClient.get<Array<PictureModel>>('Game/GetPictures');
  }

  getSolutionSteps(): Observable<Array<SolutionStep>> {
    return this.httpClient.get<Array<SolutionStep>>('Game/GetSolutionSteps');
  }
}
