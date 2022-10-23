export type TextFragment = {
  text: string;
  linkUrl: string | null;
  bold: boolean;
  muted: boolean;
};

export function getDefaultTextFragment(): TextFragment {
  return {
    text: "",
    linkUrl: null,
    bold: false,
    muted: false,
  };
}
