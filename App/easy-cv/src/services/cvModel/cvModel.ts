import type { HeaderSize } from "../commonTypes/headerSize";
import type { Icon } from "../commonTypes/icons";
import type { TextFragment } from "../commonTypes/textFragment";

export type CvModel = {
  sections: CvModelSection[];
};

export type CvModelSection = {
  header: CvModelSectionHeader;
  items: CvModelItem[];
  guid: string;
};

export type CvModelSectionHeader = {
  title: string;
  subtitle: string | null;
  size: HeaderSize;
};

export type CvModelItemType = "text" | "textarea" | "panel";

export type CvModelItem = {
  type: CvModelItemType;
  guid: string;
};

export type CvModelItemText = CvModelItem & {
  icon: Icon | null;
  text: TextFragment | null;
  subtext: TextFragment | null;
  type: "text";
};

export type CvModelItemTextarea = CvModelItem & {
  text: TextFragment;
  type: "textarea";
};

export type CvModelItemPanel = CvModelItem & {
  imageUrl: string | null;
  title: TextFragment | null;
  subtitle: TextFragment | null;
  description: TextFragment | null;
  longText: TextFragment | null;
  rating: number | null;
  type: "panel";
};
