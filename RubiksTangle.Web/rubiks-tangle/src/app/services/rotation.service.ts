import { Injectable } from '@angular/core';
import { CardItem } from '../models/card-item';

@Injectable({
  providedIn: 'root'
})
export class RotationService {

  constructor() { }

  setState(rotation: number): string {
    switch (rotation) {
      case 0:
        return 'default';
      case 1:
        return 'rotated_90';
      case 2:
        return 'rotated_180';
      case 3:
        return 'rotated_270';
      default:
        return 'default';
    }
  }

  rotate(item: CardItem): void {
    switch (item.state) {
      case 'default':
        item.state = 'rotated_90';
        break;
      case 'rotated_90':
        item.state = 'rotated_180';
        break;
      case 'rotated_180':
        item.state = 'rotated_270';
        break;
      case 'rotated_270':
        item.state = 'default';
        break;
      default:
    }
  }
}
