<%@ Page Language="C#"
    Inherits="Ict.Petra.WebServer.TDesktop"
    validateRequest="false"
    src="Desktop.aspx.cs" %>
<!DOCTYPE html>
<html lang="en">
<head>
<meta charset="utf-8">
<meta http-equiv="x-ua-compatible" content="ie=edge, chrome=1" />
<meta name="description" content="JavaScript desktop environment built with jQuery." />
<title>OpenPetra Desktop</title>
<link rel="stylesheet" href="jQueryDesktop/css/reset.css" />
<link rel="stylesheet" href="jQueryDesktop/css/desktop.css" />
</head>
<body>
<div class="abs" id="wrapper">
  <div class="abs" id="desktop">
    <a class="abs icon" style="left:20px;top:20px;" href="#icon_dock_computer">
      <img src="jQueryDesktop/images/icons/icon_32_computer.png" />
      Computer
    </a>
    <a class="abs icon" style="left:20px;top:100px;" href="#icon_dock_drive">
      <img src="jQueryDesktop/images/icons/icon_32_drive.png" />
      Hard Drive
    </a>
    <a class="abs icon" style="left:20px;top:180px;" href="#icon_dock_disc">
      <img src="jQueryDesktop/images/icons/icon_32_disc.png" />
      Audio CD
    </a>
    <a class="abs icon" style="left:20px;top:260px;" href="#icon_dock_network">
      <img src="jQueryDesktop/images/icons/icon_32_network.png" />
      Network
    </a>
    <div id="window_computer" class="abs window">
      <div class="abs window_inner">
        <div class="window_top">
          <span class="float_left">
            <img src="jQueryDesktop/images/icons/icon_16_computer.png" />
            Computer
          </span>
          <span class="float_right">
            <a href="#" class="window_min"></a>
            <a href="#" class="window_resize"></a>
            <a href="#icon_dock_computer" class="window_close"></a>
          </span>
        </div>
        <div class="abs window_content">
          <div class="window_aside">
            Hello. You look nice today!
          </div>
          <div class="window_main">
            <table class="data">
              <thead>
                <tr>
                  <th class="shrink">
                    &nbsp;
                  </th>
                  <th>
                    Name
                  </th>
                  <th>
                    Date Modified
                  </th>
                  <th>
                    Date Created
                  </th>
                  <th>
                    Size
                  </th>
                  <th>
                    Kind
                  </th>
                </tr>
              </thead>
              <tbody>
                <tr>
                  <td>
                    <img src="jQueryDesktop/images/icons/icon_16_drive.png" />
                  </td>
                  <td>
                    Hard Drive
                  </td>
                  <td>
                    Today
                  </td>
                  <td>
                    &mdash;
                  </td>
                  <td>
                    200 GB
                  </td>
                  <td>
                    Volume
                  </td>
                </tr>
                <tr>
                  <td>
                    <img src="jQueryDesktop/images/icons/icon_16_disc.png" />
                  </td>
                  <td>
                    Audio CD
                  </td>
                  <td>
                    &mdash;
                  </td>
                  <td>
                    &mdash;
                  </td>
                  <td>
                    2.92 GB
                  </td>
                  <td>
                    Media
                  </td>
                </tr>
                <tr>
                  <td>
                    <img src="jQueryDesktop/images/icons/icon_16_network.png" />
                  </td>
                  <td>
                    Network
                  </td>
                  <td>
                    &mdash;
                  </td>
                  <td>
                    &mdash;
                  </td>
                  <td>
                    &mdash;
                  </td>
                  <td>
                    LAN
                  </td>
                </tr>
                <tr>
                  <td>
                    <img src="jQueryDesktop/images/icons/icon_16_folder_remote.png" />
                  </td>
                  <td>
                    Shared Project Files
                  </td>
                  <td>
                    Yesterday
                  </td>
                  <td>
                    12/29/08
                  </td>
                  <td>
                    524 MB
                  </td>
                  <td>
                    Folder
                  </td>
                </tr>
                <tr>
                  <td>
                    <img src="jQueryDesktop/images/icons/icon_16_documents.png" />
                  </td>
                  <td>
                    Documents
                  </td>
                  <td>
                    Yesterday
                  </td>
                  <td>
                    12/29/08
                  </td>
                  <td>
                    524 MB
                  </td>
                  <td>
                    Folder
                  </td>
                </tr>
                <tr>
                  <td>
                    <img src="jQueryDesktop/images/icons/icon_16_system.png" />
                  </td>
                  <td>
                    Preferences
                  </td>
                  <td>
                    &mdash;
                  </td>
                  <td>
                    &mdash;
                  </td>
                  <td>
                    &mdash;
                  </td>
                  <td>
                    System
                  </td>
                </tr>
                <tr>
                  <td>
                    <img src="jQueryDesktop/images/icons/icon_16_trash.png" />
                  </td>
                  <td>
                    Trash
                  </td>
                  <td>
                    Today
                  </td>
                  <td>
                    &mdash;
                  </td>
                  <td>
                    &mdash;
                  </td>
                  <td>
                    Bin
                  </td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
        <div class="abs window_bottom">
          Build: TK421
        </div>
      </div>
      <span class="abs ui-resizable-handle ui-resizable-se"></span>
    </div>
    <div id="window_drive" class="abs window">
      <div class="abs window_inner">
        <div class="window_top">
          <span class="float_left">
            <img src="jQueryDesktop/images/icons/icon_16_drive.png" />
            Hard Drive
          </span>
          <span class="float_right">
            <a href="#" class="window_min"></a>
            <a href="#" class="window_resize"></a>
            <a href="#icon_dock_drive" class="window_close"></a>
          </span>
        </div>
        <div class="abs window_content">
          <div class="window_aside">
            Storage in use: 119.1 GB
          </div>
          <div class="window_main">
            <table class="data">
              <thead>
                <tr>
                  <th class="shrink">
                    &nbsp;
                  </th>
                  <th>
                    Name
                  </th>
                  <th>
                    Date Modified
                  </th>
                  <th>
                    Date Created
                  </th>
                  <th>
                    Size
                  </th>
                  <th>
                    Kind
                  </th>
                </tr>
              </thead>
              <tbody>
                <tr>
                  <td>
                    <img src="jQueryDesktop/images/icons/icon_16_page.png" />
                  </td>
                  <td>
                    .DS_Store
                  </td>
                  <td>
                    Yesterday
                  </td>
                  <td>
                    &mdash;
                  </td>
                  <td>
                    6 KB
                  </td>
                  <td>
                    Hidden
                  </td>
                </tr>
                <tr>
                  <td>
                    <img src="jQueryDesktop/images/icons/icon_16_folder_home.png" />
                  </td>
                  <td>
                    Default User
                  </td>
                  <td>
                    Today
                  </td>
                  <td>
                    &mdash;
                  </td>
                  <td>
                    &mdash;
                  </td>
                  <td>
                    Folder
                  </td>
                </tr>
                <tr>
                  <td>
                    <img src="jQueryDesktop/images/icons/icon_16_folder.png" />
                  </td>
                  <td>
                    Applications
                  </td>
                  <td>
                    Yesterday
                  </td>
                  <td>
                    &mdash;
                  </td>
                  <td>
                    &mdash;
                  </td>
                  <td>
                    Folder
                  </td>
                </tr>
                <tr>
                  <td>
                    <img src="jQueryDesktop/images/icons/icon_16_folder.png" />
                  </td>
                  <td>
                    Developer
                  </td>
                  <td>
                    12/29/08
                  </td>
                  <td>
                    &mdash;
                  </td>
                  <td>
                    &mdash;
                  </td>
                  <td>
                    Folder
                  </td>
                </tr>
                <tr>
                  <td>
                    <img src="jQueryDesktop/images/icons/icon_16_folder.png" />
                  </td>
                  <td>
                    Library
                  </td>
                  <td>
                    09/11/09
                  </td>
                  <td>
                    &mdash;
                  </td>
                  <td>
                    &mdash;
                  </td>
                  <td>
                    Folder
                  </td>
                </tr>
                <tr>
                  <td>
                    <img src="jQueryDesktop/images/icons/icon_16_folder.png" />
                  </td>
                  <td>
                    System
                  </td>
                  <td>
                    Yesterday
                  </td>
                  <td>
                    &mdash;
                  </td>
                  <td>
                    &mdash;
                  </td>
                  <td>
                    Folder
                  </td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
        <div class="abs window_bottom">
          Free: 80.9 GB
        </div>
      </div>
      <span class="abs ui-resizable-handle ui-resizable-se"></span>
    </div>
    <div id="window_disc" class="abs window">
      <div class="abs window_inner">
        <div class="window_top">
          <span class="float_left">
            <img src="jQueryDesktop/images/icons/icon_16_disc.png" />
            Audio CD - Title of Album
          </span>
          <span class="float_right">
            <a href="#" class="window_min"></a>
            <a href="#" class="window_resize"></a>
            <a href="#icon_dock_disc" class="window_close"></a>
          </span>
        </div>
        <div class="abs window_content">
          <div class="window_aside align_center">
            <br />
            <em>Title of Album</em>
          </div>
          <div class="window_main">
            <table class="data">
              <thead>
                <tr>
                  <th class="shrink">
                    &nbsp;
                  </th>
                  <th class="shrink">
                    Track
                  </th>
                  <th>
                    Song Name
                  </th>
                  <th class="shrink">
                    Length
                  </th>
                </tr>
              </thead>
              <tbody>
                <tr>
                  <td>
                    <img src="jQueryDesktop/images/icons/icon_16_music.png" />
                  </td>
                  <td class="align_center">
                    01
                  </td>
                  <td>
                    Track One
                  </td>
                  <td class="align_right">
                    3:50
                  </td>
                </tr>
                <tr>
                  <td>
                    <img src="jQueryDesktop/images/icons/icon_16_music.png" />
                  </td>
                  <td class="align_center">
                    02
                  </td>
                  <td>
                    Track Two
                  </td>
                  <td class="align_right">
                    3:50
                  </td>
                </tr>
                <tr>
                  <td>
                    <img src="jQueryDesktop/images/icons/icon_16_music.png" />
                  </td>
                  <td class="align_center">
                    03
                  </td>
                  <td>
                    Track Three
                  </td>
                  <td class="align_right">
                    4:02
                  </td>
                </tr>
                <tr>
                  <td>
                    <img src="jQueryDesktop/images/icons/icon_16_music.png" />
                  </td>
                  <td class="align_center">
                    04
                  </td>
                  <td>
                    Track Four
                  </td>
                  <td class="align_right">
                    3:47
                  </td>
                </tr>
                <tr>
                  <td>
                    <img src="jQueryDesktop/images/icons/icon_16_music.png" />
                  </td>
                  <td class="align_center">
                    05
                  </td>
                  <td>
                    Track Five
                  </td>
                  <td class="align_right">
                    4:38
                  </td>
                </tr>
                <tr>
                  <td>
                    <img src="jQueryDesktop/images/icons/icon_16_music.png" />
                  </td>
                  <td class="align_center">
                    06
                  </td>
                  <td>
                    Track Six
                  </td>
                  <td class="align_right">
                    3:16
                  </td>
                </tr>
                <tr>
                  <td>
                    <img src="jQueryDesktop/images/icons/icon_16_music.png" />
                  </td>
                  <td class="align_center">
                    07
                  </td>
                  <td>
                    Track Seven
                  </td>
                  <td class="align_right">
                    3:53
                  </td>
                </tr>
                <tr>
                  <td>
                    <img src="jQueryDesktop/images/icons/icon_16_music.png" />
                  </td>
                  <td class="align_center">
                    08
                  </td>
                  <td>
                    Track Eight
                  </td>
                  <td class="align_right">
                    1:41
                  </td>
                </tr>
                <tr>
                  <td>
                    <img src="jQueryDesktop/images/icons/icon_16_music.png" />
                  </td>
                  <td class="align_center">
                    09
                  </td>
                  <td>
                    Track Nine
                  </td>
                  <td class="align_right">
                    3:40
                  </td>
                </tr>
                <tr>
                  <td>
                    <img src="jQueryDesktop/images/icons/icon_16_music.png" />
                  </td>
                  <td class="align_center">
                    10
                  </td>
                  <td>
                    Track Ten
                  </td>
                  <td class="align_right">
                    4:33
                  </td>
                </tr>
                <tr>
                  <td>
                    <img src="jQueryDesktop/images/icons/icon_16_music.png" />
                  </td>
                  <td class="align_center">
                    11
                  </td>
                  <td>
                    Track Eleven
                  </td>
                  <td class="align_right">
                    3:49
                  </td>
                </tr>
                <tr>
                  <td>
                    <img src="jQueryDesktop/images/icons/icon_16_music.png" />
                  </td>
                  <td class="align_center">
                    12
                  </td>
                  <td>
                    Track Twelve
                  </td>
                  <td class="align_right">
                    1:11
                  </td>
                </tr>
                <tr>
                  <td class="shrink">
                    <img src="jQueryDesktop/images/icons/icon_16_music.png" />
                  </td>
                  <td class="align_center">
                    13
                  </td>
                  <td>
                    Track Thirteen
                  </td>
                  <td class="align_right">
                    6:17
                  </td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
        <div class="abs window_bottom">
          Genre: Rock/Rap
        </div>
      </div>
      <span class="abs ui-resizable-handle ui-resizable-se"></span>
    </div>
    <div id="window_network" class="abs window">
      <div class="abs window_inner">
        <div class="window_top">
          <span class="float_left">
            <img src="jQueryDesktop/images/icons/icon_16_network.png" />
            Network
          </span>
          <span class="float_right">
            <a href="#" class="window_min"></a>
            <a href="#" class="window_resize"></a>
            <a href="#icon_dock_network" class="window_close"></a>
          </span>
        </div>
        <div class="abs window_content">
          <div class="window_aside">
            Local Network Resources
          </div>
          <div class="window_main">
            <table class="data">
              <thead>
                <tr>
                  <th class="shrink">
                    &nbsp;
                  </th>
                  <th>
                    Name
                  </th>
                  <th class="shrink">
                    Operating System
                  </th>
                  <th class="shrink">
                    Version
                  </th>
                </tr>
              </thead>
              <tbody>
                <tr>
                  <td>
                    <img src="jQueryDesktop/images/icons/icon_16_server.png" />
                  </td>
                  <td>
                    Urban Terror - <em>Game Server</em>
                  </td>
                  <td>
                    Linux
                  </td>
                  <td>
                    Ubuntu
                  </td>
                </tr>
                <tr>
                  <td>
                    <img src="jQueryDesktop/images/icons/icon_16_folder_remote.png" />
                  </td>
                  <td>
                    Shared Project Files
                  </td>
                  <td>
                    Linux
                  </td>
                  <td>
                    Red Hat
                  </td>
                </tr>
                <tr>
                  <td>
                    <img src="jQueryDesktop/images/icons/icon_16_vpn.png" />
                  </td>
                  <td>
                    Remote Desktop VPN
                  </td>
                  <td>
                    Windows
                  </td>
                  <td>
                    XP
                  </td>
                </tr>
                <tr>
                  <td>
                    <img src="jQueryDesktop/images/icons/icon_16_computer.png" />
                  </td>
                  <td>
                    Michael Scott
                  </td>
                  <td>
                    Mac OS
                  </td>
                  <td>
                    10.5
                  </td>
                </tr>
                <tr>
                  <td>
                    <img src="jQueryDesktop/images/icons/icon_16_computer.png" />
                  </td>
                  <td>
                    Dwight Schrute
                  </td>
                  <td>
                    Mac OS
                  </td>
                  <td>
                    10.6
                  </td>
                </tr>
                <tr>
                  <td>
                    <img src="jQueryDesktop/images/icons/icon_16_computer.png" />
                  </td>
                  <td>
                    Jim Halpert
                  </td>
                  <td>
                    Mac OS
                  </td>
                  <td>
                    10.6
                  </td>
                </tr>
                <tr>
                  <td>
                    <img src="jQueryDesktop/images/icons/icon_16_computer.png" />
                  </td>
                  <td>
                    Pam Beesly
                  </td>
                  <td>
                    Mac OS
                  </td>
                  <td>
                    10.5
                  </td>
                </tr>
                <tr>
                  <td>
                    <img src="jQueryDesktop/images/icons/icon_16_computer.png" />
                  </td>
                  <td>
                    Ryan Howard
                  </td>
                  <td>
                    Mac OS
                  </td>
                  <td>
                    10.5
                  </td>
                </tr>
                <tr>
                  <td>
                    <img src="jQueryDesktop/images/icons/icon_16_computer.png" />
                  </td>
                  <td>
                    Jan Levinson
                  </td>
                  <td>
                    Mac OS
                  </td>
                  <td>
                    10.5
                  </td>
                </tr>
                <tr>
                  <td>
                    <img src="jQueryDesktop/images/icons/icon_16_computer.png" />
                  </td>
                  <td>
                    Roy Anderson
                  </td>
                  <td>
                    Windows
                  </td>
                  <td>
                    7
                  </td>
                </tr>
                <tr>
                  <td>
                    <img src="jQueryDesktop/images/icons/icon_16_computer.png" />
                  </td>
                  <td>
                    Stanley Hudson
                  </td>
                  <td>
                    Windows
                  </td>
                  <td>
                    Vista
                  </td>
                </tr>
                <tr>
                  <td>
                    <img src="jQueryDesktop/images/icons/icon_16_computer.png" />
                  </td>
                  <td>
                    Kevin Malone
                  </td>
                  <td>
                    Windows
                  </td>
                  <td>
                    Vista
                  </td>
                </tr>
                <tr>
                  <td>
                    <img src="jQueryDesktop/images/icons/icon_16_computer.png" />
                  </td>
                  <td>
                    Angela Martin
                  </td>
                  <td>
                    Windows
                  </td>
                  <td>
                    Vista
                  </td>
                </tr>
                <tr>
                  <td>
                    <img src="jQueryDesktop/images/icons/icon_16_computer.png" />
                  </td>
                  <td>
                    Oscar Martinez
                  </td>
                  <td>
                    Windows
                  </td>
                  <td>
                    Vista
                  </td>
                </tr>
                <tr>
                  <td>
                    <img src="jQueryDesktop/images/icons/icon_16_computer.png" />
                  </td>
                  <td>
                    Phyllis Lapin
                  </td>
                  <td>
                    Windows
                  </td>
                  <td>
                    Vista
                  </td>
                </tr>
                <tr>
                  <td>
                    <img src="jQueryDesktop/images/icons/icon_16_computer.png" />
                  </td>
                  <td>
                    Creed Bratton
                  </td>
                  <td>
                    Windows
                  </td>
                  <td>
                    7
                  </td>
                </tr>
                <tr>
                  <td>
                    <img src="jQueryDesktop/images/icons/icon_16_computer.png" />
                  </td>
                  <td>
                    Meredith Palmer
                  </td>
                  <td>
                    Windows
                  </td>
                  <td>
                    Vista
                  </td>
                </tr>
                <tr>
                  <td>
                    <img src="jQueryDesktop/images/icons/icon_16_computer.png" />
                  </td>
                  <td>
                    Toby Flenderson
                  </td>
                  <td>
                    Windows
                  </td>
                  <td>
                    Vista
                  </td>
                </tr>
                <tr>
                  <td>
                    <img src="jQueryDesktop/images/icons/icon_16_computer.png" />
                  </td>
                  <td>
                    Darryl Philbin
                  </td>
                  <td>
                    Windows
                  </td>
                  <td>
                    Vista
                  </td>
                </tr>
                <tr>
                  <td>
                    <img src="jQueryDesktop/images/icons/icon_16_computer.png" />
                  </td>
                  <td>
                    Kelly Kapoor
                  </td>
                  <td>
                    Windows
                  </td>
                  <td>
                    Vista
                  </td>
                </tr>
                <tr>
                  <td>
                    <img src="jQueryDesktop/images/icons/icon_16_computer.png" />
                  </td>
                  <td>
                    Andy Bernard
                  </td>
                  <td>
                    Windows
                  </td>
                  <td>
                    Vista
                  </td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
        <div class="abs window_bottom">
          LAN: Corporate Intranet
        </div>
      </div>
      <span class="abs ui-resizable-handle ui-resizable-se"></span>
    </div>
  </div>
  <div class="abs" id="bar_top">
    <span class="float_right" id="clock"></span>
    <ul>
      <li>
        <a class="menu_trigger" href="#">File</a>
        <ul class="menu">
          <li>
            <a href="#logout" id="logout">Logout</a>
          </li>
        </ul>
      </li>
      <li>
        <a class="menu_trigger" href="#">Credits</a>
        <ul class="menu">
          <li>
            <a href="http://sonspring.com/journal/jquery-desktop">JQuery Desktop Demo built by Nathan Smith</a>
          </li>
          <li>
            <a href="http://tango.freedesktop.org/Tango_Desktop_Project">Icons - Tango Desktop Project</a>
          </li>
        </ul>
      </li>
    </ul>
  </div>
  <div class="abs" id="bar_bottom">
    <a class="float_left" href="#" id="show_desktop" title="Show Desktop">
      <img src="jQueryDesktop/images/icons/icon_22_desktop.png" />
    </a>
    <ul id="dock">
      <li id="icon_dock_computer">
        <a href="#window_computer">
          <img src="jQueryDesktop/images/icons/icon_22_computer.png" />
          Computer
        </a>
      </li>
      <li id="icon_dock_drive">
        <a href="#window_drive">
          <img src="jQueryDesktop/images/icons/icon_22_drive.png" />
          Hard Drive
        </a>
      </li>
      <li id="icon_dock_disc">
        <a href="#window_disc">
          <img src="jQueryDesktop/images/icons/icon_22_disc.png" />
          Audio CD
        </a>
      </li>
      <li id="icon_dock_network">
        <a href="#window_network">
          <img src="jQueryDesktop/images/icons/icon_22_network.png" />
          Network
        </a>
      </li>
    </ul>
  </div>
</div>
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.18/jquery-ui.min.js"></script>
<script src="jQueryDesktop/js/jquery.desktop.js"></script>
<script src="js/desktop.js"></script>
</body>
</html>