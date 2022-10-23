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

export enum CvModelItemType {
  Text = "Text",
  Textarea = "Textarea",
  Panel = "Panel",
  Header = "Header",
}

export type CvModelItem = {
  type: CvModelItemType;
  guid: string;
};

export type CvModelSectionHeader = CvModelItem & {
  title: string;
  subtitle: string | null;
  size: HeaderSize;
  type: CvModelItemType.Header;
};

export type CvModelItemText = CvModelItem & {
  icon: Icon | null;
  text: TextFragment | null;
  subtext: TextFragment | null;
  type: CvModelItemType.Text;
};

export type CvModelItemTextarea = CvModelItem & {
  text: string;
  type: CvModelItemType.Textarea;
};

export type CvModelItemPanel = CvModelItem & {
  imageUrl: string | null;
  title: TextFragment | null;
  subtitle: TextFragment | null;
  description: TextFragment | null;
  longText: TextFragment | null;
  rating: number | null;
  type: CvModelItemType.Panel;
};
