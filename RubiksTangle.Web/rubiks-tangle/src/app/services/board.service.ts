import { Injectable } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { CardItem } from '../models/card-item';
import { PictureModel } from '../models/picture-model';

@Injectable({
  providedIn: 'root'
})
export class BoardService {

  constructor(private readonly domSanitizer: DomSanitizer) { }

  createEmptyBoard() : Array<any> {
    return new Array<any>(9)
      .fill(null)
      .map((_, index) => ({
        id: index + 1,
        ordinalNumber: index + 1,
        rotation: 0,
        src: null,
        state: 'default'
      }));
  }
  createCardBoard(pictures: PictureModel[]) : Array<CardItem> {
    return pictures.map(result => {
      let objectURL = 'data:image/jpeg;base64,' + result.picture;
      let item: CardItem = {
        id: result.id,
        rotation: result.rotation,
        ordinalNumber: result.ordinalNumber,
        src: this.domSanitizer.bypassSecurityTrustUrl(objectURL),
        state: 'default'
      };
      return item;
    });
  }
}
