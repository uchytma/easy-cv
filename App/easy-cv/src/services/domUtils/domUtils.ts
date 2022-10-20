import type { Position } from "./position";

/*
 * returns absolute position of element from top left of whole document
 */

export function getAbsolutePosition(element: HTMLElement, window: Window): Position {
  const rect = element.getBoundingClientRect();
  return {
    top: rect.top + window.scrollY,
    left: rect.left + window.scrollX,
  };
}
