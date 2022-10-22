export enum HeaderSize {
  Big = "Big",
  Normal = "Normal",
  Small = "Small",
}

export const HeaderSizeLabels = new Map<string, string>([
  [HeaderSize.Big, "Velká"],
  [HeaderSize.Normal, "Normální"],
  [HeaderSize.Small, "Malá"],
]);
