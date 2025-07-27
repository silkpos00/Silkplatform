<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cu_Items.aspx.cs" MasterPageFile="~/Site.Master" Inherits="AdminPanel.Forms.cu_Items" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .section-box {
            background-color: #fff;
            border-radius: 8px;
            padding: 25px;
            margin-bottom: 40px;
            box-shadow: 0 0 15px rgba(0,0,0,0.05);
        }

        .sidebar-fixed-center {
            position: fixed;
            top: 200px;
            left: 280px;
            width: auto;
            display: flex;
            flex-direction: column;
            gap: 0px;
            z-index: 1100;
            max-height: calc(100vh - 80px);
            overflow-y: auto;
            background-color: #fff;
            padding: 15px;
            border-radius: 15px;
            /*box-shadow: 0 0 15px rgba(0,0,0,0.1);*/
        }

        @media (max-width: 1200px) {
            .sidebar-col {
                display: none !important;
            }
        }

        .section-highlighted {
            border: 2px solid #0d6efd !important;
            border-radius: 8px;
            scroll-margin-top: 70px; /* تا فاصله مناسب برای scroll به سکشن */
        }

        .sidebar-fixed-center a.active {
            background-color: #e9f5ff;
            color: #0d6efd;
            font-weight: bold;
            border-left: 4px solid #0d6efd;
        }

        .list-group-item.active {
            border: none !important; /* حذف تمام بوردرها */
            border-left: 4px solid #0d6efd !important; /* فقط بوردر چپ */
            background-color: #e9f5ff !important; /* رنگ پس‌زمینه انتخابی */
            color: #0d6efd !important; /* رنگ متن */
            font-weight: 600;
        }

        .list-group-item {
            border: none !important; /* حذف بوردرهای پیش‌فرض از همه لینک‌ها */
        }

        .sidebar-fixed-center {
            border-radius: 0 !important;
        }

        .filter-left {
            flex: 1; /* به فیلتر اجازه می‌ده فضای باقی‌مانده رو بگیره */
        }

        .button-right {
            display: flex;
            justify-content: flex-end; /* دکمه‌ها رو به انتهای سمت راست بچسبونه */
            gap: 0.5rem; /* فاصله بین دکمه‌ها */
            min-width: 200px; /* حداقل عرض برای بخش دکمه‌ها */
        }
    </style>
    <div class="row">
        <div class="col-md-3 sidebar-col ">
            <div class="sidebar-fixed-center list-group">
                <a href="#sectionItemInfo" class="list-group-item list-group-item-action d-flex align-items-center gap-2 active"
                    onclick="scrollToSection('sectionItemInfo'); return false;">
                    <i class="fas fa-info-circle"></i>Item Info
                </a>
                <a href="#sectionItemDetails" class="list-group-item list-group-item-action d-flex align-items-center gap-2"
                    onclick="scrollToSection('sectionItemDetails'); return false;">
                    <i class="fas fa-list-ul"></i>Item Details
                </a>
                <a href="#sectionManufacture" class="list-group-item list-group-item-action d-flex align-items-center gap-2"
                    onclick="scrollToSection('sectionManufacture'); return false;">
                    <i class="fas fa-industry"></i>Manufacture
                </a>
                <a href="#sectionHardware" class="list-group-item list-group-item-action d-flex align-items-center gap-2"
                    onclick="scrollToSection('sectionHardware'); return false;">
                    <i class="fas fa-microchip"></i>Hardware
                </a>
                <a href="#sectionSchedual" class="list-group-item list-group-item-action d-flex align-items-center gap-2"
                    onclick="scrollToSection('sectionSchedual'); return false;">
                    <i class="fas fa-calendar-alt"></i>Schedual
                </a>
                <a href="#sectionHappyHours" class="list-group-item list-group-item-action d-flex align-items-center gap-2"
                    onclick="scrollToSection('sectionHappyHours'); return false;">
                    <i class="fas fa-clock"></i>Happy Hours
                </a>
            </div>
        </div>
        <!-- محتوای اصلی فرم -->
        <div class="col-md-9">
            <!-- 🔒 دکمه‌های ثابت -->
            <div class="form-toolbar py-3 px-2" style="z-index: 100; position: sticky; top: 80px;">
                <div class="d-flex justify-content-between align-items-center">
                    <div class="d-flex gap-3">
                        <button type="submit" class="btn btn-primary d-flex align-items-center gap-2">
                            <i class="fas fa-save"></i>Save
                        </button>
                        <button type="reset" class="btn btn-warning d-flex align-items-center gap-2">
                            <i class="fas fa-undo"></i>Reset
                        </button>
                    </div>
                    <button type="button" class="btn btn-info d-flex align-items-center gap-2" onclick="window.location.href='rd_items.aspx';">
                        <i class="fas fa-list"></i>List
                    </button>

                </div>
            </div>
            <div class="form-scroll-container mt-3 pe-2 " style="overflow-y: auto; flex: 1;" >
                <!-- Item Info -->
                <div id="sectionItemInfo" class="section-box needs-validation" novalidate>
                    <h4 class="mb-4">Item Info</h4>
                    <div class="row g-4">

                        <div class="col-md-6">
                            <label class="form-label" for="txtItemName" >Item Name</label>
                            <input type="text" class="form-control" id="txtItemName" required/>
                            <div class="valid-feedback">Looks good!</div>
                            <div class="invalid-feedback">Please enter your name.</div>
                        </div>
                        <div class="col-md-6">
                            <label class="form-label" for="txtNameOnDisplay">Name on Display</label>
                            <input type="text" class="form-control" id="txtNameOnDisplay" />
                        </div>
                        <div class="col-md-6">
                            <label class="form-label" for="ddlCategory">Category</label>
                            <div class="dropdown-wrapper" style="position: relative;">
                                <select id="ddlCategory" class="selectpicker w-100" data-style="btn-default" data-live-search="true"></select>
                                <div id="ddlCategory_loadingSpinner" style="display: none; position: absolute; top: 0; left: 0; right: 0; bottom: 0; background: rgba(255, 255, 255, 0.6); z-index: 10; display: flex; align-items: center; justify-content: center; pointer-events: none;">
                                    <div class="spinner-border text-primary" role="status" style="width: 1.5rem; height: 1.5rem;">
                                        <span class="visually-hidden">Loading...</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <label class="form-label" for="ddlItemSize">Size</label>
                            <div class="dropdown-wrapper" style="position: relative;">
                                <select id="ddlItemSize" class="selectpicker w-100" data-style="btn-default" data-live-search="true"></select>
                                <div id="ddlItemSize_loadingSpinner" style="display: none; position: absolute; top: 0; left: 0; right: 0; bottom: 0; background: rgba(255, 255, 255, 0.6); z-index: 10; display: flex; align-items: center; justify-content: center; pointer-events: none;">
                                    <div class="spinner-border text-primary" role="status" style="width: 1.5rem; height: 1.5rem;">
                                        <span class="visually-hidden">Loading...</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <label class="form-label" for="txtPrice">Price ($)</label>
                            <input type="text" id="txtPrice" class="form-control" />
                        </div>
                        <div class="col-md-6">
                            <label class="form-label" for="txtSort">Sort</label>
                            <input type="text" id="txtSort" class="form-control" />
                        </div>
                        <div class="col-md-6">
                            <label class="form-label" for="txtPageNo">Page Name</label>
                            <input type="text" id="txtPageNo" class="form-control" />
                        </div>
                        <div class="col-md-6">
                            <label class="form-label" for="txtPageSort">Page Sort</label>
                            <input type="text" id="txtPageSort" class="form-control" />
                        </div>
                        <div class="col-md-6">
                            <label class="form-label" for="ddlTaxRate">Tax Rate</label>
                            <div class="dropdown-wrapper" style="position: relative;">
                                <select id="ddlTaxRate" class="selectpicker w-100" data-style="btn-default" data-live-search="true"></select>
                                <!-- Spinner overlay -->
                                <div id="ddlTaxRate_loadingSpinner" style="display: none; position: absolute; top: 0; left: 0; right: 0; bottom: 0; background: rgba(255, 255, 255, 0.6); z-index: 10; display: flex; align-items: center; justify-content: center; pointer-events: none;">
                                    <div class="spinner-border text-primary" role="status" style="width: 1.5rem; height: 1.5rem;">
                                        <span class="visually-hidden">Loading...</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3 mt-12">
                            <div class="form-check">
                                <input type="checkbox" class="form-check-input" id="chkIsActive" />
                                <label class="form-check-label" for="chkIsActive">Active</label>
                            </div>
                        </div>
                        <div class="col-md-3 mt-12">
                            <div class="form-check">
                                <input type="checkbox" class="form-check-input" id="chkIsVisible" />
                                <label class="form-check-label" for="chkIsVisible">Visible</label>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Item Details -->
                <div id="sectionItemDetails" class="section-box">
                    <h4 class="mb-4">Item Details</h4>
                    <div class="row g-4">
                        <div class="col-md-6">
                            <label class="form-label" for="ddlModifierGroup">Modifier Category</label>
                            <div class="dropdown-wrapper" style="position: relative;">
                                <select id="ddlModifierGroup" class="selectpicker w-100" data-style="btn-default" data-live-search="true"></select>
                                <div id="ddlModifierGroup_loadingSpinner" style="display: none; position: absolute; top: 0; left: 0; right: 0; bottom: 0; background: rgba(255, 255, 255, 0.6); z-index: 10; display: flex; align-items: center; justify-content: center; pointer-events: none;">
                                    <div class="spinner-border text-primary" role="status" style="width: 1.5rem; height: 1.5rem;">
                                        <span class="visually-hidden">Loading...</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <label class="form-label" for="ddlModifiers">Included Modifiers</label>
                            <div class="dropdown-wrapper" style="position: relative;">
                                <select id="ddlModifiers"
                                    class="selectpicker w-100"
                                    data-style="btn-default"
                                    multiple
                                    data-actions-box="true"
                                    data-selected-text-format="count > 8"
                                    title="Nothing selected">
                                </select>
                                <!-- Spinner overlay -->
                                <div id="ddlModifiers_loadingSpinner"
                                    style="display: none; position: absolute; top: 0; left: 0; right: 0; bottom: 0; background: rgba(255, 255, 255, 0.6); z-index: 10; display: flex; align-items: center; justify-content: center; pointer-events: none;">
                                    <div class="spinner-border text-primary" role="status" style="width: 1.5rem; height: 1.5rem;">
                                        <span class="visually-hidden">Loading...</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <label class="form-label" for="txtItemQty">Item Qty</label>
                            <input type="text" id="txtItemQty" class="form-control" />
                        </div>


                        <div class="col-md-6">
                            <label class="form-label" for="txtMaxModQty">Maximum Modifier Qty</label>
                            <input type="text" id="txtMaxModQty" class="form-control" />
                        </div>
                        <div class="col-md-6">
                            <label class="form-label" for="txtMinModQty">Minimum Modifier Qty</label>
                            <input type="text" id="txtMinModQty" class="form-control" />
                        </div>
                        <div class="col-md-6">
                            <label class="form-label" for="txtFreeModQty">Free Modifier Qty</label>
                            <input type="text" id="txtFreeModQty" class="form-control" />
                        </div>


                        <div class="col-md-6 mt-8">
                            <div class="form-check">
                                <input type="checkbox" class="form-check-input" id="chkFoodstampable" />
                                <label class="form-check-label" for="chkFoodstampable">Foodstamp</label>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <label class="form-label">Background Color</label>
                            <div id="color-picker-classic"></div>
                            <asp:HiddenField ID="hfSelectedColor" runat="server" Value="#FFA500" />
                        </div>

                    </div>
                </div>

                <!-- Manufacture -->
                <div id="sectionManufacture" class="section-box">
                    <h4 class="mb-4">Manufacture</h4>
                    <div class="row g-4">
                        <div class="col-md-6">
                            <label class="form-label" for="txtMainBarcode">Main Barcode</label>
                            <input type="text" id="txtMainBarcode" class="form-control" />
                        </div>
                        <div class="col-md-6">
                            <label class="form-label" for="txtBarcode">Barcode</label>
                            <input type="text" id="txtBarcode" class="form-control" />
                        </div>
                        <div class="col-md-6">
                            <label class="form-label" for="txtManufacture">Manufacture</label>
                            <input type="text" id="txtManufacture" class="form-control" />
                        </div>
                        <div class="col-md-6">
                            <label class="form-label" for="txtItemNumber">Item Number</label>
                            <input type="text" id="txtItemNumber" class="form-control" />
                        </div>
                        <div class="col-md-6 mt-3">
                            <div class="form-check">
                                <input type="checkbox" class="form-check-input" id="chkIsWeightRequired" />
                                <label class="form-check-label" for="chkIsWeightRequired">Weight Required</label>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Hardware -->
                <div id="sectionHardware" class="section-box">
                    <h4 class="mb-4">Hardware</h4>
                    <div class="row g-4">
                        <div class="col-md-6">
                            <label class="form-label" for="ddlPrinters">Printer</label>
                            <div class="dropdown-wrapper" style="position: relative;">
                                <select id="ddlPrinters" class="selectpicker w-100" data-style="btn-default" data-live-search="true"></select>
                                <div id="ddlPrinters_loadingSpinner" style="display: none; position: absolute; top: 0; left: 0; right: 0; bottom: 0; background: rgba(255, 255, 255, 0.6); z-index: 10; display: flex; align-items: center; justify-content: center; pointer-events: none;">
                                    <div class="spinner-border text-primary" role="status" style="width: 1.5rem; height: 1.5rem;">
                                        <span class="visually-hidden">Loading...</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <label class="form-label" for="ddlKDS">Kitchen Display</label>
                            <div class="dropdown-wrapper" style="position: relative;">
                                <select id="ddlKDS" class="selectpicker w-100" data-style="btn-default" data-live-search="true"></select>
                                <div id="ddlKDS_loadingSpinner" style="display: none; position: absolute; top: 0; left: 0; right: 0; bottom: 0; background: rgba(255, 255, 255, 0.6); z-index: 10; display: flex; align-items: center; justify-content: center; pointer-events: none;">
                                    <div class="spinner-border text-primary" role="status" style="width: 1.5rem; height: 1.5rem;">
                                        <span class="visually-hidden">Loading...</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Schedual -->
                <div id="sectionSchedual" class="section-box">
                    <h4 class="mb-4">Schedual</h4>
                    <div class="row g-4">
                        <div class="col-md-6">
                            <label class="form-label" for="ddlSchedualWeekdays">Weekdays</label>
                            <div class="dropdown-wrapper" style="position: relative;">
                                <select id="ddlSchedualWeekdays"
                                    class="selectpicker w-100"
                                    data-style="btn-default"
                                    multiple
                                    data-actions-box="true"
                                    data-selected-text-format="count > 8"
                                    title="Nothing selected">
                                </select>

                                <!-- Spinner overlay -->
                                <div id="ddlSchedualWeekdays_loadingSpinner"
                                    style="display: none; position: absolute; top: 0; left: 0; right: 0; bottom: 0; background: rgba(255, 255, 255, 0.6); z-index: 10; display: flex; align-items: center; justify-content: center; pointer-events: none;">
                                    <div class="spinner-border text-primary" role="status" style="width: 1.5rem; height: 1.5rem;">
                                        <span class="visually-hidden">Loading...</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <label class="form-label" for="txtSchedualStartTime">Start Time</label>
                            <input type="text" id="txtSchedualStartTime" class="form-control ui-timepicker-input" placeholder="20:00" autocomplete="off" />
                        </div>
                        <div class="col-md-3">
                            <label class="form-label" for="txtSchedualEndTime">End Time</label>
                            <input type="text" id="txtSchedualEndTime" class="form-control ui-timepicker-input" placeholder="20:00" autocomplete="off" />
                        </div>
                    </div>
                </div>
                <!-- Happy Hours -->
                <div id="sectionHappyHours" class="section-box">
                    <h4 class="mb-4">Happy Hours</h4>
                    <div class="row g-4">
                        <div class="col-md-6">
                            <label class="form-label" for="ddlHappyHoursWeekdays">Weekdays</label>
                            <div class="dropdown-wrapper" style="position: relative;">
                                <select id="ddlHappyHoursWeekdays" class="selectpicker w-100"
                                    data-style="btn-default"
                                    multiple
                                    data-actions-box="true"
                                    data-selected-text-format="count > 8"
                                    title="Nothing selected">
                                </select>
                                <!-- Spinner overlay -->
                                <div id="ddlHappyHoursWeekdays_loadingSpinner" style="display: none; position: absolute; top: 0; left: 0; right: 0; bottom: 0; background: rgba(255, 255, 255, 0.6); z-index: 10; display: flex; align-items: center; justify-content: center; pointer-events: none;">
                                    <div class="spinner-border text-primary" role="status" style="width: 1.5rem; height: 1.5rem;">
                                        <span class="visually-hidden">Loading...</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <label class="form-label" for="txtHappyHoursStartTime">Start Time</label>
                            <input type="text" id="txtHappyHoursStartTime" class="form-control ui-timepicker-input" placeholder="20:00" autocomplete="off" />
                        </div>
                        <div class="col-md-2">
                            <label class="form-label" for="txtHappyHoursEndTime">End Time</label>
                            <input type="text" id="txtHappyHoursEndTime" class="form-control ui-timepicker-input" placeholder="20:00" autocomplete="off" />
                        </div>
                        <div class="col-md-2">
                            <label class="form-label" for="txtHappyHoursPrice">Price($)</label>
                            <input type="text" id="txtHappyHoursPrice" class="form-control" placeholder="0:00" />
                        </div>
                    </div>
                </div>

                <!-- دکمه ارسال -->
                <div class="mb-5">
                    <input type="button" id="btnSave" class="btn btn-success px-4 py-2" value="Submit" />
                </div>
            </div>
        </div>
    </div>
    <script src="../SilkJS/cu_items.js"></script>
</asp:Content>
