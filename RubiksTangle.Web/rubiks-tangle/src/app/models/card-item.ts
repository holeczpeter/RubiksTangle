export class CardItem {
  id: number;
  rotation: number;
  ordinalNumber: number;
  src: any | null;
  state: string | null;
  constructor(id: number, rotation: number, ordinalNumber: number, src: any, state: string) {
    this.id = id;
    this.rotation = rotation;
    this.ordinalNumber = ordinalNumber;
    this.src = src;
    this.state = state
  }

}
