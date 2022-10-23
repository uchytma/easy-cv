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

export const sizeOptions = Object.keys(HeaderSize).map((key) => ({
  value: key,
  text: HeaderSizeLabels.get(key) ?? "??",
}));
