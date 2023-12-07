import { AppState } from "../AppState.js"
import { Report } from "../models/Report.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class ReportsService {
  async getReportsByRestaurantId(restaurantId) {
    const res = await api.get(`api/restaurants/${restaurantId}/reports`)
    logger.log('GOT REPORTS', res.data)
    const newReports = res.data.map(pojo => new Report(pojo))
    AppState.reports = newReports
    // AppState.reports = res.data.map(pojo => new Report(pojo))
  }
}

export const reportsService = new ReportsService()