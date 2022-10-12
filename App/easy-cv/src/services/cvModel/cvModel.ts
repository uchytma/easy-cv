import type { HeaderSize } from "../commonTypes/headerSize";

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
  subtitle: string;
  size: HeaderSize;
};

export type CvModelIcon = "phone" | "email" | "location" | "linkedin" | "github";

export type CvModelText = {
  text: string;
  linkUrl: string | null;
  bold: boolean;
  muted: boolean;
};

export type CvModelItemType = "text" | "textarea" | "panel";

export type CvModelItem = {
  type: CvModelItemType;
  guid: string;
};

export type CvModelItemText = CvModelItem & {
  icon: CvModelIcon | null;
  text: CvModelText | null;
  subtext: CvModelText | null;
  type: "text";
};

export type CvModelItemTextarea = CvModelItem & {
  text: CvModelText;
  type: "textarea";
};

export type CvModelItemPanel = CvModelItem & {
  imageUrl: string | null;
  title: CvModelText | null;
  subtitle: CvModelText | null;
  description: CvModelText | null;
  longText: CvModelText | null;
  rating: number | null;
  type: "panel";
};
