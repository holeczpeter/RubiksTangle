import { animate, state, style, transition, trigger } from '@angular/animations';
import { CdkDragDrop } from '@angular/cdk/drag-drop';
import { Component, OnInit } from '@angular/core';
import { concatMap, map } from 'rxjs/operators';
import { CardItem } from '../../models/card-item';
import { PictureModel } from '../../models/picture-model';
import { BoardService } from '../../services/board.service';
import { GameService } from '../../services/game.service';
import { RotationService } from '../../services/rotation.service';
import { SnackbarService } from '../../services/snack-bar.service';

@Component({
  selector: 'app-board',
  templateUrl: './board.component.html',
  styleUrls: ['./board.component.scss'],
  animations: [
    trigger('rotatedState', [
      state('default', style({ transform: 'rotate(0)' })),
      state('rotated_90', style({ transform: 'rotate(90deg)' })),
      state('rotated_180', style({ transform: 'rotate(180deg)' })),
      state('rotated_270', style({ transform: 'rotate(270deg)' })),
      transition('default => rotated_90', animate('400ms ease-in')),
      transition('rotated_90 => rotated_180', animate('400ms ease-out')),
      transition('rotated_180 => rotated_270', animate('400ms ease-out')),
      transition('rotated_270 => default', animate('400ms ease-out')),
      transition('default => rotated_180', animate('800ms ease-in')),
      transition('default => rotated_270', animate('800ms ease-in'))
    ])
  ]
})

export class BoardComponent implements OnInit {
  indexOver = -1;
  pictures!: Array<CardItem>;
  results!: Array<CardItem>;

  constructor(private readonly gameService: GameService,
    private readonly boardService: BoardService,
    private snackBarService: SnackbarService,
    public rotationService: RotationService) {
  }

  ngOnInit() {
    this.gameService.getPictures().subscribe(results  => {
      this.createBoard(results)
    });
  }

  refresh(): void {
    this.gameService.cardShuffle().pipe(
      concatMap(isShuffle =>
        this.gameService.getPictures().pipe(map(results => ({ isShuffle, results }))))).subscribe(x => {
      this.snackBarService.open("A kártya keverés kész, a kártyák elhelyezésének animálása folyamatban", true);
      this.createBoard(x.results);
    });
  }

  createBoard(pictures: PictureModel[]): void {
    this.results = this.boardService.createEmptyBoard();
    this.pictures = this.boardService.createCardBoard(pictures)
    this.pictures.forEach(x => {
      setTimeout(() => x.state = this.rotationService.setState(x.rotation), 1000);
    })
  }

  getSolutionSteps(): void {
    this.gameService.getSolutionSteps().subscribe(steps => {
      this.snackBarService.open("A megoldás kész, a kártyák elhelyezésének animálása folyamatban", true);
      steps.forEach(step => {
        var oderID = step.order + 1;
        var currentPicture = this.pictures.find(x => x.id == step.pictureId)!;
        var currentResult = this.results.find(x => x.id == oderID)!;
        setTimeout(() => {
          if (currentPicture && currentResult) {
            currentResult.src = currentPicture?.src;
            currentResult.state = 'default'
            currentPicture.src = null;
            setTimeout(() => currentResult.state = this.rotationService.setState(step.rotation), 800);
          }
        }, step.order * 2500);
      })
    });
  }

  isActive(): boolean {
    return this.results && this.results.every(x => x.src == null);
  }

  drop(event: CdkDragDrop<any>): void {
    if (event.previousContainer != event.container) {
      if (event.container.data.src !== undefined) {
        if (event.previousContainer.data.src != undefined) {
          if (event.container.data.src != undefined) return;
          event.container.data.src = event.previousContainer.data.src;
          event.previousContainer.data.src = null;
        }
        else {
          event.container.data.src[event.previousIndex] = event.previousContainer.data[event.previousIndex];
        }
      }
      else {
        if (event.container.data.src === undefined && event.previousContainer.data.src !== undefined) event.previousContainer.data.src = null;
      }
    }
  }
}

