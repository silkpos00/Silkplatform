<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Items.aspx.cs" MasterPageFile="~/Site.Master" Inherits="AdminPanel.Forms.Items" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-12 mb-4">
            <small class="fw-large">MenuBuilder >> Items</small>
            <div class="bs-stepper vertical wizard-modern wizard-modern-vertical-icons-example mt-2">
                <div class="bs-stepper-header">
                    <div class="step" data-target="#Page1">
                        <button type="button" class="step-trigger">
                            <span class="bs-stepper-circle">
                                <i class="icon-base bx bx-detail"></i>
                            </span>
                            <span class="bs-stepper-label">
                                <span class="bs-stepper-title">Item Info</span>
                                <span class="bs-stepper-subtitle">Enter Item Info</span>
                            </span>
                        </button>
                    </div>
                    <div class="line"></div>
                    <div class="step" data-target="#Page2">
                        <button type="button" class="step-trigger">
                            <span class="bs-stepper-circle">
                                <i class="icon-base bx bx-user"></i>
                            </span>
                            <span class="bs-stepper-label">
                                <span class="bs-stepper-title">Item Details</span>
                                <span class="bs-stepper-subtitle">Enter Item Details</span>
                            </span>
                        </button>
                    </div>
                    <div class="line"></div>
                    <div class="step" data-target="#Page3">
                        <button type="button" class="step-trigger">
                            <span class="bs-stepper-circle">
                                <i class="icon-base bx bx-user"></i>
                            </span>
                            <span class="bs-stepper-label">
                                <span class="bs-stepper-title">Manufacture</span>
                                <span class="bs-stepper-subtitle">Enter Manufacture</span>
                            </span>
                        </button>
                    </div>
                    <div class="line"></div>
                    <div class="step" data-target="#Page4">
                        <button type="button" class="step-trigger">
                            <span class="bs-stepper-circle">
                                <i class="icon-base bx bxl-instagram"></i>
                            </span>
                            <span class="bs-stepper-label">
                                <span class="bs-stepper-title">Hardware</span>
                                <span class="bs-stepper-subtitle">Setup Hardware</span>
                            </span>
                        </button>
                    </div>
                    <div class="line"></div>
                    <div class="step" data-target="#Page5">
                        <button type="button" class="step-trigger">
                            <span class="bs-stepper-circle">
                                <i class="icon-base bx bxl-instagram"></i>
                            </span>
                            <span class="bs-stepper-label">
                                <span class="bs-stepper-title">Schedual</span>
                                <span class="bs-stepper-subtitle">Setup Schedual</span>
                            </span>
                        </button>
                    </div>
                    <div class="line"></div>
                    <div class="step" data-target="#Page6">
                        <button type="button" class="step-trigger">
                            <span class="bs-stepper-circle">
                                <i class="icon-base bx bxl-instagram"></i>
                            </span>
                            <span class="bs-stepper-label">
                                <span class="bs-stepper-title">Happy Hours</span>
                                <span class="bs-stepper-subtitle">Setup Happy Hours</span>
                            </span>
                        </button>
                    </div>
                </div>
                <div class="bs-stepper-content">
                    <!-- Account Details -->
                    <div id="Page1" class="content">
                        <div class="content-header mb-4">
                            <h6 class="mb-0">Item Info</h6>
                            <small>Enter Item Info.</small>
                        </div>
                        <div class="row g-6">
                            <div class="col-sm-6">
                                <label class="form-label" for="txtItemName">Item name</label>
                                <asp:TextBox runat="server" ID="txtItemName" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="col-sm-6">
                                <label class="form-label" for="txtNameOnDisplay">Name on display</label>
                                <asp:TextBox runat="server" ID="txtNameOnDisplay" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="col-sm-6">
                                <label class="form-label" for="txtSort">Sort</label>
                                <asp:TextBox runat="server" ID="txtSort" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-sm-6">
                                <label class="form-label" for="txtPrice">Price($)</label>
                                <asp:TextBox runat="server" ID="txtPrice" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-sm-6">
                                <label class="form-label" for="ddlTaxRate">Tax rate</label>
                                <asp:DropDownList ID="ddlTaxRate" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                            <div class="col-sm-6">
                            </div>

                            <div class="col-sm-4">
                                <div class="form-check form-check-primary mt-4">
                                    <input type="checkbox" class="form-check-input" id="customChkActive" checked />
                                    <label class="form-check-label" for="customChkActive">Active</label>
                                </div>
                                <asp:CheckBox ID="chkActive" runat="server" Style="display: none;" />
                            </div>
                            <div class="col-sm-4">
                                <div class="form-check form-check-primary mt-4">
                                    <input type="checkbox" class="form-check-input" id="customChkVisable" checked />
                                    <label class="form-check-label" for="customChkVisable">Visable</label>
                                </div>
                                <asp:CheckBox ID="chkVisable" runat="server" Style="display: none;" />
                            </div>
                            <div class="col-sm-4 ">
                                <div class="d-flex align-items-center">
                                    <div id="color-picker-classic"></div>
                                    <label class="form-check-label ms-2" id="lbl-color-picker-classic" for="color-picker-classic">Background color</label>
                                </div>

                            </div>

                            <div class="col-12 d-flex justify-content-between">
                                <button type="button" class="btn btn-label-secondary btn-prev" disabled>
                                    <i class="icon-base bx bx-left-arrow-alt scaleX-n1-rtl icon-sm ms-sm-n2 me-sm-2"></i>
                                    <span class="align-middle d-sm-inline-block d-none">Previous</span>
                                </button>
                                <button type="button" class="btn btn-primary btn-next">
                                    <span class="align-middle d-sm-inline-block d-none me-sm-2">Next</span>
                                    <i class="icon-base bx bx-right-arrow-alt scaleX-n1-rtl icon-sm me-sm-n2"></i>
                                </button>
                            </div>
                        </div>
                    </div>
                    <!-- Personal Info -->
                    <div id="Page2" class="content">
                        <div class="content-header mb-4">
                            <h6 class="mb-0">Item Details</h6>
                            <small>Enter Item Details.</small>
                        </div>
                        <div class="row g-6">
                            <div class="col-sm-6">
                                <label class="form-label" for="txtItemQty">Item qty</label>
                                <asp:TextBox runat="server" ID="txtItemQty" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-sm-6">
                                <label class="form-label" for="txtPageNo">Page name</label>
                                <asp:TextBox runat="server" ID="txtPageNo" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-sm-6">
                                <label class="form-label" for="txtPageSort">Page sort</label>
                                <asp:TextBox runat="server" ID="txtPageSort" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-sm-6">
                                <label class="form-label" for="ddlModifierGroup">Modifier group</label>
                                <asp:DropDownList ID="ddlModifierGroup" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                            <div class="col-sm-6">
                                <label class="form-label" for="txtMinModQty">Maximum modifier qty</label>
                                <asp:TextBox runat="server" ID="txtMinModQty" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-sm-6">
                                <label class="form-label" for="txtMaxModQty">Minimum modifier qty</label>
                                <asp:TextBox runat="server" ID="txtMaxModQty" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-sm-6">
                                <label class="form-label" for="txtFreeModQty">Free modifier qty</label>
                                <asp:TextBox runat="server" ID="txtFreeModQty" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-sm-6">
                                <div class="form-check form-check-primary mt-8">
                                    <input type="checkbox" class="form-check-input" id="customChkFoodstamp" />
                                    <label class="form-check-label" for="customChkFoodstamp">Foodstamp</label>
                                </div>
                                <asp:CheckBox ID="chkFoodstamp" runat="server" Style="display: none;" />
                            </div>
                            <div class="col-12 d-flex justify-content-between">
                                <button type="button" class="btn btn-primary btn-prev">
                                    <i class="icon-base bx bx-left-arrow-alt scaleX-n1-rtl icon-sm ms-sm-n2 me-sm-2"></i>
                                    <span class="align-middle d-sm-inline-block d-none">Previous</span>
                                </button>
                                <button type="button" class="btn btn-primary btn-next">
                                    <span class="align-middle d-sm-inline-block d-none me-sm-2">Next</span>
                                    <i class="icon-base bx bx-right-arrow-alt scaleX-n1-rtl icon-sm me-sm-n2"></i>
                                </button>
                            </div>
                        </div>
                    </div>
                    <!-- Social Links -->
                    <div id="Page3" class="content">
                        <div class="content-header mb-4">
                            <h6 class="mb-0">Manufacture</h6>
                            <small>Enter Manufacture Info.</small>
                        </div>
                        <div class="row g-6">
                            <div class="col-sm-6">
                                <label class="form-label" for="txtMainBarcode">Main barcode</label>
                                <asp:TextBox runat="server" ID="txtMainBarcode" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-sm-6">
                                <label class="form-label" for="txtBarcode">Barcode</label>
                                <asp:TextBox runat="server" ID="txtBarcode" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-sm-6">
                                <label class="form-label" for="txtManufacture">Manufacture</label>
                                <asp:TextBox runat="server" ID="txtManufacture" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-sm-6">
                                <label class="form-label" for="txtItemNumber">Item number</label>
                                <asp:TextBox runat="server" ID="txtItemNumber" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-sm-6">
                                <div class="form-check form-check-primary mt-8">
                                    <input type="checkbox" class="form-check-input" id="customChkWeightRequired" checked />
                                    <label class="form-check-label" for="customChkWeightRequired">Weight Required</label>
                                </div>
                                <asp:CheckBox ID="chkWeightRequired" runat="server" Style="display: none;" />
                            </div>
                            <div class="col-12 d-flex justify-content-between">
                                <button type="button" class="btn btn-primary btn-prev">
                                    <i class="icon-base bx bx-left-arrow-alt scaleX-n1-rtl icon-sm ms-sm-n2 me-sm-2"></i>
                                    <span class="align-middle d-sm-inline-block d-none">Previous</span>
                                </button>
                                <button type="button" class="btn btn-primary btn-next">
                                    <span class="align-middle d-sm-inline-block d-none me-sm-2">Next</span>
                                    <i class="icon-base bx bx-right-arrow-alt scaleX-n1-rtl icon-sm me-sm-n2"></i>
                                </button>
                            </div>
                        </div>
                    </div>
                    <!-- Social Links -->
                    <div id="Page4" class="content">
                        <div class="content-header mb-4">
                            <h6 class="mb-0">Hardware</h6>
                            <small>Enter Hardware Setup.</small>
                        </div>
                        <div class="row g-6">
                            <div class="col-sm-6 ">
                                <label class="form-label" for="ddlPrinters">Printer</label>
                                <asp:DropDownList ID="ddlPrinters" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                            <div class="col-sm-6">
                                <label class="form-label" for="ddlKDS">Kitchen display</label>
                                <asp:DropDownList ID="ddlKDS" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                            <div class="col-12 d-flex justify-content-between">
                                <button type="button" class="btn btn-primary btn-prev">
                                    <i class="icon-base bx bx-left-arrow-alt scaleX-n1-rtl icon-sm ms-sm-n2 me-sm-2"></i>
                                    <span class="align-middle d-sm-inline-block d-none">Previous</span>
                                </button>
                                <button type="button" class="btn btn-primary btn-next">
                                    <span class="align-middle d-sm-inline-block d-none me-sm-2">Next</span>
                                    <i class="icon-base bx bx-right-arrow-alt scaleX-n1-rtl icon-sm me-sm-n2"></i>
                                </button>
                            </div>
                        </div>
                    </div>
                    <!-- Social Links -->
                    <div id="Page5" class="content">
                        <div class="content-header mb-4">
                            <h6 class="mb-0">Schedual</h6>
                            <small>Enter Schedual.</small>
                        </div>
                        <div class="row g-6">
                            <div class="col-sm-6">
                                <label for="ddlSchedualWeekdays" class="form-label">Weekdays</label>
                                <asp:DropDownList runat="server" ID="ddlSchedualWeekdays" CssClass="selectpicker w-100" data-style="btn-default" data-actions-box="true" multiple>
                                    <asp:ListItem Value="0">Sun</asp:ListItem>
                                    <asp:ListItem Value="1">Mon</asp:ListItem>
                                    <asp:ListItem Value="2">Tue</asp:ListItem>
                                    <asp:ListItem Value="3">Wed</asp:ListItem>
                                    <asp:ListItem Value="4">Thu</asp:ListItem>
                                    <asp:ListItem Value="5">Fri</asp:ListItem>
                                    <asp:ListItem Value="6">Sat</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-sm-3">
                                <label for="txtSchedualStartTime" class="form-label">Start Time</label>
                                <asp:TextBox runat="server" ID="txtSchedualStartTime" placeholder="20:00" autocomplete="off" CssClass="form-control ui-timepicker-input" />
                            </div>
                            <div class="col-sm-3">
                                <label for="txtSchedualEndTime" class="form-label">End Time</label>
                                <asp:TextBox runat="server" ID="txtSchedualEndTime" placeholder="20:00" autocomplete="off" CssClass="form-control ui-timepicker-input" />
                            </div>
                            <div class="col-12 d-flex justify-content-between">
                                <button type="button" class="btn btn-primary btn-prev">
                                    <i class="icon-base bx bx-left-arrow-alt scaleX-n1-rtl icon-sm ms-sm-n2 me-sm-2"></i>
                                    <span class="align-middle d-sm-inline-block d-none">Previous</span>
                                </button>
                                <button type="button" class="btn btn-primary btn-next">
                                    <span class="align-middle d-sm-inline-block d-none me-sm-2">Next</span>
                                    <i class="icon-base bx bx-right-arrow-alt scaleX-n1-rtl icon-sm me-sm-n2"></i>
                                </button>
                            </div>
                        </div>
                    </div>
                    <!-- Social Links -->
                    <div id="Page6" class="content">
                        <div class="content-header mb-4">
                            <h6 class="mb-0">Happy Hours</h6>
                            <small>Enter Happy Hours.</small>
                        </div>
                        <div class="row g-6">
                            <div class="col-sm-6">
                                <label for="ddlHappyHoursWeekdays" class="form-label">Weekdays</label>
                                <asp:DropDownList runat="server" ID="ddlHappyHoursWeekdays" CssClass="selectpicker w-100" data-style="btn-default" data-actions-box="true" multiple>
                                    <asp:ListItem Value="0">Sun</asp:ListItem>
                                    <asp:ListItem Value="1">Mon</asp:ListItem>
                                    <asp:ListItem Value="2">Tue</asp:ListItem>
                                    <asp:ListItem Value="3">Wed</asp:ListItem>
                                    <asp:ListItem Value="4">Thu</asp:ListItem>
                                    <asp:ListItem Value="5">Fri</asp:ListItem>
                                    <asp:ListItem Value="6">Sat</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-sm-3">
                                <label for="txtHappyHoursStartTime" class="form-label">Start Time</label>
                                <asp:TextBox runat="server" ID="txtHappyHoursStartTime" placeholder="20:00" autocomplete="off" CssClass="form-control ui-timepicker-input" />
                            </div>
                            <div class="col-sm-3">
                                <label for="txtHappyHoursEndTime" class="form-label">End Time</label>
                                <asp:TextBox runat="server" ID="txtHappyHoursEndTime" placeholder="20:00" autocomplete="off" CssClass="form-control ui-timepicker-input" />
                            </div>
                            <div class="col-12 d-flex justify-content-between">
                                <button type="button" class="btn btn-primary btn-prev">
                                    <i class="icon-base bx bx-left-arrow-alt scaleX-n1-rtl icon-sm ms-sm-n2 me-sm-2"></i>
                                    <span class="align-middle d-sm-inline-block d-none">Previous</span>
                                </button>
                                <button type="button" class="btn btn-success btn-submit">Submit</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <input type="hidden" id="hfSelectedColor" runat="server" value="#FFA500" />
    <script>
        // قبل از ارسال فرم، مقدار چک‌باکس Sneat رو در کنترل سرور قرار بده
        document.addEventListener("DOMContentLoaded", function () {
            const form = document.forms[0];
            form.addEventListener("submit", function () {
                var uiCheckbox = document.getElementById("customChkActive");
                var hiddenCheckbox = document.getElementById("<%= chkActive.ClientID %>");
                hiddenCheckbox.checked = uiCheckbox.checked;

                uiCheckbox = document.getElementById("customChkVisable");
                hiddenCheckbox = document.getElementById("<%= chkVisable.ClientID %>");
                hiddenCheckbox.checked = uiCheckbox.checked;

                uiCheckbox = document.getElementById("customChkFoodstamp");
                hiddenCheckbox = document.getElementById("<%= chkFoodstamp.ClientID %>");
                hiddenCheckbox.checked = uiCheckbox.checked;

                uiCheckbox = document.getElementById("customChkWeightRequired");
                hiddenCheckbox = document.getElementById("<%= chkWeightRequired.ClientID %>");
                hiddenCheckbox.checked = uiCheckbox.checked;

            });

            //************************************* */

        });
        $(function () {
            var txtSchedualStartTime = $('#txtSchedualStartTime'),
                txtSchedualEndTime = $('#txtSchedualEndTime'),
                txtHappyHoursStartTime = $('#txtHappyHoursStartTime'),
                txtHappyHoursEndTime = $('#txtHappyHoursEndTime');
            // 24 Hours Format
            if (txtSchedualStartTime.length) {
                txtSchedualStartTime.timepicker({
                    show: '24:00',
                    timeFormat: 'H:i',
                    orientation: isRtl ? 'r' : 'l'
                });
            }
            if (txtSchedualEndTime.length) {
                txtSchedualEndTime.timepicker({
                    show: '24:00',
                    timeFormat: 'H:i',
                    orientation: isRtl ? 'r' : 'l'
                });
            }
            if (txtHappyHoursStartTime.length) {
                txtHappyHoursStartTime.timepicker({
                    show: '24:00',
                    timeFormat: 'H:i',
                    orientation: isRtl ? 'r' : 'l'
                });
            }
            if (txtHappyHoursEndTime.length) {
                txtHappyHoursEndTime.timepicker({
                    show: '24:00',
                    timeFormat: 'H:i',
                    orientation: isRtl ? 'r' : 'l'
                });
            }
        });
        $(function () {
            const Picker = document.querySelector('#color-picker-classic');

            const classicPickr = new Pickr({
                el: Picker,
                theme: 'classic',
                default: '#FFA500', // رنگ پیش‌فرض دلخواه
                swatches: [
                    '#026576', '#abd9c5', '#1199b7', '#5ebdd8', '#cada72',
                    '#e4cab5', '#ada0a5', '#00FFFF', '#F0FFFF', '#000000',
                    '#0000FF', '#A52A2A', '#00008B', '#A9A9A9', '#006400',
                    '#BDB76B', '#FF8C00', '#9932CC', '#8B0000', '#E9967A',
                    '#9400D3', '#FFD700', '#008000', '#4B0082', '#F0E68C',
                    '#ADD8E6', '#E0FFFF', '#90EE90', '#D3D3D3', '#FFB6C1',
                    '#FFFFE0', '#00FF00', '#FF00FF', '#800000', '#000080',
                    '#808000', '#FFA500', '#FFC0CB', '#FF0000', '#FFFFFF',
                    '#FFFF00'
                ],
                components: {
                    preview: false,
                    opacity: false,
                    hue: false,
                    interaction: {
                        hex: false,
                        rgba: false,
                        hsla: false,
                        hsva: false,
                        cmyk: false,
                        input: false,
                        clear: false,
                        save: false
                    }
                }
            });
            classicPickr.on('swatchselect', (color) => {
                const hex = color.toHEXA().toString(); // مثل "#026576"
                classicPickr.setColor(hex); // ست‌کردن رنگ انتخابی
                document.getElementById('<%= hfSelectedColor.ClientID %>').value = hex;
                classicPickr.hide(); // بستن پنل
                Picker.textContent = 'background color';
                   // alert(document.getElementById('<%= hfSelectedColor.ClientID %>').value);
            });


        });
    </script>
</asp:Content>
