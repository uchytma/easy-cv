export function moveUp<T>(array: Array<T>, item: T): void {
  const index = array.indexOf(item);
  if (index > 0) {
    swapItems(array, index, index - 1);
  }
}

export function moveDown<T>(array: Array<T>, item: T): void {
  const index = array.indexOf(item);
  if (index < array.length - 1) {
    swapItems(array, index, index + 1);
  }
}

function swapItems<T>(array: Array<T>, index1: number, index2: number): Array<T> {
  array.splice(index2, 0, array.splice(index1, 1)[0]);
  return array;
}
