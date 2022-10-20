import type { CvModelItem } from "../cvModel/cvModel";
import type { Position } from "./position";

export type EventItemSelected = {
  callerPosition: Position;
  item: CvModelItem;
};
