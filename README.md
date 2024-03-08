
# IN DEVELOPMENT - RECON FORENSIC TOOL

[![License](https://img.shields.io/badge/license-MIT-blue.svg)](https://opensource.org/licenses/MIT)

## Overview

The Recon and Forensic Tool is a application designed to streamline reconnaissance and forensic analysis tasks. It offers a range of features and modules to aid investigators in gathering, analyzing, and interpreting digital evidence.

## Features

- **Upload Forensic Images**: Easily upload forensic images as VHD, to cloud storage services such as Azure or AWS.
- **Automated Analysis**: Utilize built-in algorithms and analysis tools to automatically process forensic images and extract valuable insights.
- **Modular Architecture**: The tools are modular, allowing for easy integration of additional recon and forensic modules and extensions to cater to specific investigation needs.
- **Interactive Dashboard**: Access a user-friendly dashboard to visualize analysis results and generate comprehensive reports.

## Modules
### Recon
#### DNS
- **Zone Transfer / AXFR:** Retrieves DNS Zone informations
### Forensics

**Collected Data:**

**Extraction of Configuration Data:**

-   **File Associations:** Retrieved using `ASSOC`.
-   **File Attributes:** Retrieved using `ATTRIB`.
-   **Device Drivers:** List retrieved using `DRIVERQUERY`.
-   **Services Information:** Retrieved using `sc query`.
-   **Time Zone Settings:** Retrieved using `w32tm /tz`.
-   **Registry Hives Data:** Collected using `regdump` and `reglookup48`.

**Extraction of Communication Protocol Data:**

-   **Network Configuration:** Retrieved using `netsh`.
-   **Active TCP Connections:** Displayed using `netstat`.
-   **Network Interface Configuration:** Detailed information retrieved using `ipconfig`.
-   **Address Resolution Protocol (ARP):** Displayed and modified using `ARP`.
-   **Running Processes:** List displayed using `TASKLIST`.
-   **Recent Files and History:** Retrieved from user directory under "C:\Documents and Settings".
-   **User Accounts Information:** Retrieved using `net user`.
-   **Printer Information:** Displayed using `net print`.
-   **Open Files on Server:** Displayed using `openfiles /query`.

**Additional Information:**

-   **System Logs:** Logs stored in "system32\config" directory such as "AppEvent.Evt," "SecEvent.Evt," and "SysEvent.Evt."
-   **Event Triggers and Creation:** User-specific event triggers and manual event creation facilitated by tools like `eventtriggers` and `eventcreate`. Event logs can be exported for later analysis and correlation.

## Contributing

Contributions are welcome! Please fork the repository and submit a pull request with your changes.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
