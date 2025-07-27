const baseUrl = "https://localhost:7136/api";
$(document).ready(function () {
    $('#ddlModifiers_loadingSpinner').hide();

    const id = getParameterByName('itemID');
    $.when(
    ).done(function () {
        if (id) {
            GetItemByID(id);
        } else {
            BindCategory().done(function () {
                $('#ddlCategory').val([]).selectpicker('render');
            }),
                BindModifierCategory().done(function () {
                    $('#ddlModifierGroup').val([]).selectpicker('render');
                }),
                BindItemSize(-1).done(function () {
                    $('#ddlItemSize').val([]).selectpicker('render');
                }),
                BindPrinters().done(function () {
                    $('#ddlPrinters').val([]).selectpicker('render');
                }),
                GetKitchenDisplays().done(function () {
                    $('#ddlKDS').val([]).selectpicker('render');
                }),
                BindTaxRate().done(function () {
                    $('#ddlTaxRate').val([]).selectpicker('render');
                }),
                GetWeekDays().done(function () {
                    $('#ddlSchedualWeekdays').val([]).selectpicker('render');
                    $('#ddlHappyHoursWeekdays').val([]).selectpicker('render');
                })
        }
    });
    $('#ddlModifierGroup').on('change', function () {
        var selectedValue = $(this).val();
        GetModifiers(selectedValue == 0 ? -1 : selectedValue).done(function () {
            $('#ddlModifiers').val([]).selectpicker('render');
        });
    });
    $('#ddlCategory').on('change', function () {
       
        var selectedValue = $(this).val();
       BindItemSize(selectedValue == 0 ? -1 : selectedValue).done(function () {
            $('#ddlItemSize').val([]).selectpicker('render');
        });
    });
});
// تابع اسکرول به سکشن
function scrollToSection(id, highlight = true) {
    const target = document.getElementById(id);
    if (!target) return;

    // حذف border از همه سکشن‌ها
    document.querySelectorAll(".section-box").forEach(sec => {
        sec.classList.remove("section-highlighted");
    });

    // فقط اگر highlight=true باشه بوردر اضافه کن
    if (highlight) {
        target.classList.add("section-highlighted");
    }

    // اسکرول نرم
    window.scrollTo({
        top: target.offsetTop - 150,
        behavior: "smooth"
    });

    // لینک فعال
    document.querySelectorAll(".sidebar-fixed-center .list-group-item").forEach(link => {
        link.classList.remove("active");
    });

    const clickedLink = document.querySelector(`.sidebar-fixed-center a[href="#${id}"]`);
    if (clickedLink) {
        clickedLink.classList.add("active");
    }
}
// اجرای پیش‌فرض برای اولین آیتم (اختیاری، برای بار اول)
document.addEventListener("DOMContentLoaded", function () {
    scrollToSection('sectionItemInfo');
});
document.addEventListener("DOMContentLoaded", function () {
    // کپی وضعیت چک‌باکس‌های UI به کنترل‌های asp
    const form = document.forms[0];
    form.addEventListener("submit", function () {
        document.getElementById("<%= chkActive.ClientID %>").checked = document.getElementById("customChkActive").checked;
        document.getElementById("<%= chkVisable.ClientID %>").checked = document.getElementById("customChkVisable").checked;
        document.getElementById("<%= chkFoodstamp.ClientID %>").checked = document.getElementById("customChkFoodstamp").checked;
        document.getElementById("<%= chkWeightRequired.ClientID %>").checked = document.getElementById("customChkWeightRequired").checked;
    });

    // راه‌اندازی timepicker
    function initTimePicker(id) {
        const el = document.getElementById(id);
        if (!el) return;
        $(el).timepicker({
            show: '24:00',
            timeFormat: 'H:i',
            orientation: 'l'
        });
    }
    initTimePicker("txtSchedualStartTime");
    initTimePicker("txtSchedualEndTime");
    initTimePicker("txtHappyHoursStartTime");
    initTimePicker("txtHappyHoursEndTime");

    // راه‌اندازی انتخاب رنگ با Pickr
    const Picker = document.querySelector('#color-picker-classic');
    const classicPickr = new Pickr({
        el: Picker,
        theme: 'classic',
        default: '#FFA500',
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
        const hex = color.toHEXA().toString();
        classicPickr.setColor(hex);
        document.getElementById('<%= hfSelectedColor.ClientID %>').value = hex;
        classicPickr.hide();
    });
});
document.addEventListener("DOMContentLoaded", function () {
    const sidebarLinks = document.querySelectorAll(".sidebar-fixed-center a");
    const allSections = document.querySelectorAll("div[id^='section']");

    sidebarLinks.forEach(link => {
        link.addEventListener("click", function (e) {
            e.preventDefault();

            // حذف بوردر از همه سکشن‌ها
            allSections.forEach(sec => sec.classList.remove("section-highlighted"));

            // دریافت آیدی هدف
            const targetId = this.getAttribute("href").replace("#", "");
            const target = document.getElementById(targetId);
            if (!target) return;

            // هایلایت و اسکرول
            target.classList.add("section-highlighted");
            window.scrollTo({
                top: target.offsetTop - 150,
                behavior: "smooth"
            });

            // active برای دکمه‌ها
            sidebarLinks.forEach(l => l.classList.remove("active"));
            this.classList.add("active");
        });
    });
});
function BindCategory() {
    return $.ajax({
        url: baseUrl + '/MenuBuilder/GetCategory',
        type: 'POST',
        contentType: 'application/json',
        dataType: 'json',
        data: JSON.stringify({ menuID: 0, appID: 0 }),
        headers: {
            'Authorization': 'Bearer ' + getCookie('AuthToken')
        },
        beforeSend: function () {
            $('#ddlCategory_loadingSpinner').show();
        },
        success: function (d) {
            var $dropdown = $('#ddlCategory');
            $dropdown.selectpicker('destroy');
            $dropdown.empty();
            //$dropdown.append('<option value="0">Select category ..</option>');
            $.each(d.data, function (index, item) {
                $dropdown.append(
                    $('<option></option>').val(item.ID).text(item.Title)
                );
            });
        },
        error: function (xhr, status, error) {
            console.error('Error:', error);
            console.log('Error:', xhr.responseText);
        },
        complete: function () {
            $('#ddlCategory_loadingSpinner').hide();
        }
    });
}
function BindItemSize(_categoryID) {
    return $.ajax({
        url: baseUrl + '/MenuBuilder/GetItemsSize',
        type: 'POST',
        contentType: 'application/json',
        dataType: 'json',
        data: JSON.stringify({ categoryID: _categoryID }),
        headers: {
            'Authorization': 'Bearer ' + getCookie('AuthToken')
        },
        beforeSend: function () {
            $('#ddlItemSize_loadingSpinner').show();
        },
        success: function (d) {
            var $dropdown = $('#ddlItemSize');
            $dropdown.selectpicker('destroy');
            $dropdown.empty();
            $dropdown.append('<option value="0">Nothing selected</option>');
            $.each(d.data, function (index, item) {
                $dropdown.append(
                    $('<option></option>').val(item.ID).text(item.Title)
                );
            });
        },
        error: function (xhr, status, error) {
            console.error('Error:', error);
            console.log('Error:', xhr.responseText);
        },
        complete: function () {
            $('#ddlItemSize_loadingSpinner').hide();
        }
    });
}
function BindModifierCategory() {
    return $.ajax({
        url: baseUrl + '/MenuBuilder/GetModifierCategory',
        type: 'GET',
        contentType: 'application/json',
        dataType: 'json',
        headers: {
            'Authorization': 'Bearer ' + getCookie('AuthToken')
        },
        beforeSend: function () {
            $('#ddlModifierGroup_loadingSpinner').show();
        },
        success: function (d) {
            var $dropdown = $('#ddlModifierGroup');
            $dropdown.selectpicker('destroy');

            $dropdown.empty();
            $dropdown.append('<option value="0">Nothing selected</option>');
            $.each(d.data, function (index, item) {
                $dropdown.append(
                    $('<option></option>').val(item.ID).text(item.Title)
                );
            });
            //$dropdown.selectpicker('refresh');
        },
        error: function (xhr, status, error) {
            console.error('Error:', error);
            console.log('Error:', xhr.responseText);
        },
        complete: function () {
            $('#ddlModifierGroup_loadingSpinner').hide();
        }
    });
}
function BindTaxRate() {
    return $.ajax({
        url: baseUrl + '/BaseInfo/GetTaxRate',
        type: 'GET',
        contentType: 'application/json',
        dataType: 'json',
        headers: {
            'Authorization': 'Bearer ' + getCookie('AuthToken')
        },
        beforeSend: function () {
            $('#ddlTaxRate_loadingSpinner').show();
        },
        success: function (d) {
            var $dropdown = $('#ddlTaxRate');
            $dropdown.selectpicker('destroy');
            $dropdown.empty();
            $.each(d.data, function (index, item) {
                $dropdown.append(
                    $('<option></option>').val(item.Value).text(item.Title)
                );
            });
        },
        error: function (xhr, status, error) {
            console.error('Error:', error);
            console.log('Error:', xhr.responseText);
        },
        complete: function () {
            $('#ddlTaxRate_loadingSpinner').hide();
        }
    });
}
function BindPrinters() {

    return $.ajax({
        url: baseUrl + '/BaseInfo/GetPrinters',
        type: 'POST',
        contentType: 'application/json',
        dataType: 'json',
        data: JSON.stringify({ printerGroupID: 0 }),
        headers: {
            'Authorization': 'Bearer ' + getCookie('AuthToken')
        },
        beforeSend: function () {
            $('#ddlPrinters_loadingSpinner').show();
        },
        success: function (d) {
            var $dropdown = $('#ddlPrinters');
            $dropdown.selectpicker('destroy');
            $dropdown.empty();
            $.each(d.data, function (index, item) {
                $dropdown.append(
                    $('<option></option>').val(item.ID).text(item.Title + "(" + item.IP + ")")
                );
            });

        },
        error: function (xhr, status, error) {
            console.error('Error:', error);
            console.log('Error:', xhr.responseText);
        },
        complete: function () {
            $('#ddlPrinters_loadingSpinner').hide();
        }
    });
}
function GetKitchenDisplays() {
    return $.ajax({
        url: baseUrl + '/BaseInfo/GetKitchenDisplays',
        type: 'POST',
        contentType: 'application/json',
        dataType: 'json',
        data: JSON.stringify({ kitchenDisplayGroupID: 0 }),
        headers: {
            'Authorization': 'Bearer ' + getCookie('AuthToken')
        },
        beforeSend: function () {
            $('#ddlKDS_loadingSpinner').show();
        },
        success: function (d) {
            var $dropdown = $('#ddlKDS');
            $dropdown.selectpicker('destroy');
            $dropdown.empty();
            $.each(d.data, function (index, item) {
                $dropdown.append(
                    $('<option></option>').val(item.ID).text(item.Title + "(" + item.IP + ")")
                );
            });
            //$dropdown.selectpicker('refresh');
        },
        error: function (xhr, status, error) {
            console.error('Error:', error);
            console.log('Error:', xhr.responseText);
        },
        complete: function () {
            $('#ddlKDS_loadingSpinner').hide();
        }
    });
}
function GetWeekDays() {
    return $.ajax({
        url: baseUrl + '/BaseInfo/GetWeekDays',
        type: 'GET',
        contentType: 'application/json',
        dataType: 'json',
        headers: {
            'Authorization': 'Bearer ' + getCookie('AuthToken')
        },
        beforeSend: function () {
            $('#ddlSchedualWeekdays_loadingSpinner').show();
            $('#ddlHappyHoursWeekdays_loadingSpinner').show();
        },
        success: function (d) {
            var $dropdown1 = $('#ddlSchedualWeekdays');
            var $dropdown2 = $('#ddlHappyHoursWeekdays');
            $dropdown1.selectpicker('destroy');
            $dropdown2.selectpicker('destroy');
            $dropdown1.empty();
            $dropdown2.empty();
            $.each(d.data, function (index, item) {
                $dropdown1.append(
                    $('<option></option>').val(item.ID).text(item.Title)
                );
                $dropdown2.append(
                    $('<option></option>').val(item.ID).text(item.Title)
                );
            });
        },
        error: function (xhr, status, error) {
            console.error('Error:', error);
            console.log('Error:', xhr.responseText);
        },
        complete: function () {
            $('#ddlSchedualWeekdays_loadingSpinner').hide();
            $('#ddlHappyHoursWeekdays_loadingSpinner').hide();
        }
    });
}
function GetModifiers(_categoryID) {
    return $.ajax({
        url: baseUrl + '/MenuBuilder/GetModifiersByCategory',
        type: 'POST',
        contentType: 'application/json',
        dataType: 'json',
        data: JSON.stringify({ categoryID: _categoryID }),
        headers: {
            'Authorization': 'Bearer ' + getCookie('AuthToken')
        },
        beforeSend: function () {
            $('#ddlModifiers_loadingSpinner').show();

        },
        success: function (d) {
            var $dropdown = $('#ddlModifiers');
            $dropdown.selectpicker('destroy');
            //$dropdownx.empty().selectpicker('refresh');
            $('#ddlModifiers').selectpicker('destroy');
            $dropdown.empty();
            $.each(d.data, function (index, item) {
                $dropdown.append(
                    $('<option></option>').val(item.ID).text(item.Title)
                );

            });
            //$dropdown.selectpicker({
            //    style: 'btn-default',
            //    actionsBox: true,
            //    selectedTextFormat: 'count > 8',
            //    multiple: true
            //});
        },
        error: function (xhr, status, error) {
            console.error('Error:', error);
            console.log('Error:', xhr.responseText);
        },
        complete: function () {
            $('#ddlModifiers_loadingSpinner').hide();
        }
    });
}
function GetItemByID(_itemID) {

    return $.ajax({
        url: baseUrl + '/MenuBuilder/GetItemByID',
        type: 'POST',
        contentType: 'application/json',
        dataType: 'json',
        data: JSON.stringify({ itemID: _itemID }),
        headers: {
            'Authorization': 'Bearer ' + getCookie('AuthToken')
        },
        beforeSend: function () {
            //$('#ddlModifierGroup_loadingSpinner').show();
        },
        success: function (d) {
            try {
                if (!d || !d.data) return;
                const item = d.data[0];
                $('#txtItemName').val(item.Title);
                $('#txtNameOnDisplay').val(item.DisplayName);
                $('#txtPrice').val(item.Price);
                $('#txtSort').val(item.OrderSort);
                $('#txtPageNo').val(item.PageNo || '');
                $('#txtPageSort').val(item.PageSort || '');
                $('#txtItemQty').val(item.ItemQty || '');
                $('#txtMaxModQty').val(item.MaxModQty || '');
                $('#txtMinModQty').val(item.MinModQty || '');
                $('#txtFreeModQty').val(item.FreeModQty || '');
                $('#txtMainBarcode').val(item.MainBarcode || '');
                $('#txtBarcode').val(item.SKUCode || '');
                $('#txtManufacture').val(item.Manufacture || '');
                $('#txtItemNumber').val(item.ItemNumber || '');
                $('#chkIsActive').prop('checked', item.IsActive);
                $('#chkIsVisible').prop('checked', item.IsVisible);
                $('#chkFoodstampable').prop('checked', item.FoodStampable);
                $('#chkIsWeightRequired').prop('checked', item.IsWeightRequired);
                BindPrinters().done(function () {
                    $('#ddlPrinters').val(item.PrinterID).selectpicker('render');
                });
                GetKitchenDisplays().done(function () {
                    $('#ddlKDS').val(item.KitchenDisplayID).selectpicker('render');
                });
                //BindCategory().done(function () {
                //    $('#ddlCategory').val(item.GroupID).selectpicker('render');
                //});
                BindModifierCategory().done(function () {
                    $('#ddlModifierGroup').val(item.ModifierGroupID).selectpicker('render');
                    GetModifiers(item.ModifierGroupID).done(function () {
                        const modifiersString = item.IncludedModifiers;
                        const modifiersArray = modifiersString ? modifiersString.split(',') : [];
                        $('#ddlModifiers').val(modifiersArray).selectpicker('render');
                    });
                });
                BindCategory().done(function () {
                    $('#ddlCategory').val(item.GroupID).selectpicker('render');
                    BindItemSize(item.GroupID).done(function () {
                        $('#ddlItemSize').val(item.ItemSizeID).selectpicker('render');
                    });
                });
                BindTaxRate().done(function () {
                    $('#ddlTaxRate').val(item.TaxRateValue).selectpicker('render');
                });

                GetWeekDays().done(function () {
                    $('#ddlSchedualWeekdays').val([]).selectpicker('render');
                    $('#ddlHappyHoursWeekdays').val([]).selectpicker('render');
                })
            } catch (e) {
                console.log('exeption:', e);
            }

        },
        error: function (xhr, status, error) {
            console.error('Error:', error);
            console.log('Error:', xhr.responseText);
        },
        complete: function () {
        }
    });
}
function getItemModel() {
    // جمع‌آوری مقادیر از کنترل‌های فرم
    const model = {
        title: document.getElementById('txtItemName').value,
        displayName: document.getElementById('txtNameOnDisplay').value,
        groupID: parseInt($('#ddlCategory').val()) || 0,
        isActive: document.getElementById('chkIsActive').checked ? 1 : 0,
        itemSizeID: parseInt($('#ddlItemSize').val()) || 0,
        imageFile: "",
        price: parseFloat(document.getElementById('txtPrice').value) || 0,
        qty: parseFloat(document.getElementById('txtItemQty').value) || 0,
        backgroundColor: document.getElementById('hfSelectedColor').value,
        printerID: parseInt($('#ddlPrinters').val()) || 0,
        taxRateValue: parseInt($('#ddlTaxRate').val()) || 0,
        minQty: parseFloat(document.getElementById('txtMinModQty').value) || 0,
        orderSort: parseFloat(document.getElementById('txtSort').value) || 0,
        familyID: 0, // اگر کنترل مربوطه وجود دارد، مقداردهی کنید
        barcode: document.getElementById('txtBarcode').value,
        minModifier: parseFloat(document.getElementById('txtMinModQty').value) || 0,
        maxModifier: parseFloat(document.getElementById('txtMaxModQty').value) || 0,
        pageNo: document.getElementById('txtPageNo').value,
        modifierGroupID: parseInt($('#ddlModifierGroup').val()) || 0,
        isWeightRequired: document.getElementById('chkIsWeightRequired').checked ? 1 : 0,
        itemNumber: document.getElementById('txtItemNumber').value,
        kitchenDisplayID: parseInt($('#ddlKDS').val()) || 0,
        foodStampable: document.getElementById('chkFoodstampable').checked ? 1 : 0,
        unitName: "", // اگر کنترل مربوطه وجود دارد، مقداردهی کنید
        manufacture: document.getElementById('txtManufacture').value,
        skuCode: "", // اگر کنترل مربوطه وجود دارد، مقداردهی کنید
        includedModifiers: $('#ddlModifiers').val() ? $('#ddlModifiers').val().join(',') : "",
        pageNoSort: parseFloat(document.getElementById('txtPageSort').value) || 0,
        mixAndMatchGroupID: 0, // اگر کنترل مربوطه وجود دارد، مقداردهی کنید
        isVisable: document.getElementById('chkIsVisible').checked ? 1 : 0,
        maxFreeModifiersCount: parseFloat(document.getElementById('txtFreeModQty').value) || 0,
        description: "" // اگر کنترل مربوطه وجود دارد، مقداردهی کنید
    };

    return model;
}
function submitItem() {
    const itemData = getItemModel();
    return $.ajax({
        url: baseUrl + '/MenuBuilder/AddItem',
        type: 'POST',
        contentType: 'application/json',
        dataType: 'json',
        data: JSON.stringify(itemData),
        headers: {
            'Authorization': 'Bearer ' + getCookie('AuthToken')
        },
        beforeSend: function () {
            //$('#ddlModifierGroup_loadingSpinner').show();
        },
        success: function (d) {
            try {
                if (!d || !d.data) return;
                const item = d.data[0];

            } catch (e) {
                console.log('exeption:', e);
            }

        },
        error: function (xhr, status, error) {
            console.error('Error:', error);
            console.log('Error:', xhr.responseText);
        },
        complete: function () {
        }
    });
}
$(document).ready(function () {
    
    //$('#btnSave').click(function (e) {
    //    // e.preventDefault();
    //    // بررسی اعتبار

    //    if (!form.checkValidity()) {
    //        // نمایش ارورها
    //        form.classList.add("was-validated");
    //    } else {
    //        alert("Form is valid!");
    //    }
    //    //submitItem();
    //});
});




function getCookie(name) {
    var value = `; ${document.cookie}`;
    var parts = value.split(`; ${name}=`);
    if (parts.length === 2) return parts.pop().split(';').shift();
    return '';
}
function getParameterByName(name, url) {
    if (!url) url = window.location.href;

    name = name.replace(/[\[\]]/g, '\\$&'); // Escape for special characters

    const regex = new RegExp('[?&]' + name + '(=([^&#]*)|&|#|$)'),
        results = regex.exec(url);

    if (!results) return null;
    if (!results[2]) return '';

    return decodeURIComponent(results[2].replace(/\+/g, ' '));
}
