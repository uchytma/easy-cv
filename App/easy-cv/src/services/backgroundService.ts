import dotsImageUrl from "@/assets/imgs/dots.jpg";

export type Background = {
  /**
   * Unique id of the background
   */
  id: number;

  /**
   * Url of the background image
   */
  imgSrcUrl: string | null;

  /**
   * Name of background image
   */
  name: string;
};

const supportedBackgrounds: Background[] = [
  { id: 1, imgSrcUrl: null, name: "Empty" },
  { id: 2, imgSrcUrl: dotsImageUrl, name: "Puntíky" },
];

/**
 * Returns all possible backgrounds
 */
export function getBackgrounds(): Background[] {
  return supportedBackgrounds;
}
