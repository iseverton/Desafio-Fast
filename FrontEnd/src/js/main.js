import { initTabs } from "./tab.js";
import { renderEmployees } from "./employees.js";
import { renderWorkshops } from "./workshops.js";
import { initCharts } from "./charts.js";
import { employees, workshops } from "./data.js";
document.addEventListener("DOMContentLoaded", () => {
  initTabs();
  renderEmployees(employees);
  renderWorkshops(workshops, employees);
  initCharts(employees, workshops);
});
