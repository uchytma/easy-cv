export enum Icon {
  Phone = "Phone",
  Email = "Email",
  Location = "Location",
  Linkedin = "Linkedin",
  Github = "Github",
  Close = "Close",
  Trash = "Trash",
  Up = "Up",
  Down = "Down",
}

export const IconLabels = new Map<string, string>([
  [Icon.Phone, "Telefon"],
  [Icon.Email, "Email"],
  [Icon.Location, "Adresa"],
  [Icon.Linkedin, "Linkedin"],
  [Icon.Github, "Github"],
  [Icon.Close, "Křížek"],
  [Icon.Trash, "Popelnice"],
  [Icon.Up, "Nahoru"],
  [Icon.Down, "Dolů"],
]);

export const iconOptions = Object.keys(Icon).map((key) => ({ value: key, text: IconLabels.get(key) ?? "??" }));
