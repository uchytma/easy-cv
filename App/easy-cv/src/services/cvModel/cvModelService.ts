import type { CvModel } from "@/services/cvModel/cvModel";

import axios from "axios";

/**
 * Returns default cv model, with prefilled sections and items.
 */
export async function getDefaultCv(): Promise<CvModel> {
  const res = await axios.get<CvModel>(`/defaultCv.json`);
  console.log(res);
  return res.data;
}
