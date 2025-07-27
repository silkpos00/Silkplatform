<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="rd_Category.ascx.cs" Inherits="AdminPanel.Forms.rd_Category" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card mt-4">
        <div class="card-body">
            <table id="myTable" class="display nowrap table table-bordered" style="width: 100%">
                <thead>
                    <!-- ردیف اصلی هدر -->
                    <tr class="main-header">
                        <th>ID</th>
                        <th>Title</th>
                        <th>Menu ID</th>
                        <th>Visible</th>
                        <th>Color</th>
                        <th>Image</th>
                    </tr>
                    <!-- ردیف فیلترها -->
                    <tr class="filter-row">
                        <th></th>
                        <th></th>
                        <th></th>
                        <th></th>
                        <th></th>
                        <th></th>
                    </tr>
                </thead>
            </table>
        </div>
    </div>
    <script>
        $(document).ready(function () {
            var table = $('#myTable').DataTable({
                language: {
                    paginate: {
                        previous: '<i class="fas fa-angle-left"></i>',
                        next: '<i class="fas fa-angle-right"></i>'
                    }
                },
                processing: true,
                serverSide: false,
                ajax: {
                    url: 'https://localhost:7136/api/MenuBuilder/GetCategory',
                    type: 'POST',
                    contentType: 'application/json',
                    dataType: 'json',
                    data: function (d) {
                        return JSON.stringify({ menuID: 0, appID: 0 });
                    },
                    beforeSend: function (xhr) {
                        const token = getCookie('AuthToken');
                        xhr.setRequestHeader('Authorization', 'Bearer ' + token);
                    },
                    dataSrc: 'data'
                },
                columns: [
                    { data: 'ID', title: 'ID' },
                    { data: 'Title', title: 'Title' },
                    { data: 'MenuID', title: 'Menu ID' },
                    { data: 'IsVisible', title: 'Visible' },
                    { data: 'bgColor', title: 'Color' },
                    {
                        data: 'bgImage',
                        title: 'Image',
                        render: function (data) {
                            return `<img src="${data}" width="40" height="40" alt="image">`;
                        }
                    }
                ],
                dom: 'Bfrtip',
                buttons: [
                    {
                        extend: 'collection',
                        text: '<i class="fas fa-file-export me-1"></i> Export Options',
                        className: 'btn btn-outline-primary',
                        buttons: [
                            {
                                extend: 'csv',
                                text: '<i class="fas fa-file-csv me-1"></i> CSV',
                                className: 'btn btn-outline-secondary',
                                exportOptions: {
                                    columns: [0, 1, 2, 3, 4], // ستون‌های غیر عکس
                                    format: {
                                        header: function (data, columnIdx) {
                                            const th = $('#myTable thead tr:not(.filter-row)').first().find('th').eq(columnIdx);
                                            return $(th).text().trim();
                                        },
                                        body: function (data, row, column, node) {
                                            if (typeof data === 'string') {
                                                const div = document.createElement('div');
                                                div.innerHTML = data;
                                                return div.textContent || div.innerText || '';
                                            }
                                            return data ?? '';
                                        }
                                    }
                                },
                                action: function (e, dt, button, config) {
                                    const filterRow = $('#myTable thead tr.filter-row').detach();
                                    $.fn.dataTable.ext.buttons.csvHtml5.action.call(this, e, dt, button, config);
                                    if (filterRow.length > 0) {
                                        $('#myTable thead').append(filterRow);
                                    }
                                }
                            },
                            {
                                extend: 'excel',
                                text: '<i class="fas fa-file-excel me-1"></i> Excel',
                                className: 'btn btn-outline-secondary',
                                exportOptions: {
                                    columns: [0, 1, 2, 3, 4], // بدون ستون عکس
                                    format: {
                                        header: function (data, columnIdx) {
                                            const th = $('#myTable thead tr:not(.filter-row)').first().find('th').eq(columnIdx);
                                            return $(th).text().trim();
                                        },
                                        body: function (data, row, column, node) {
                                            if (typeof data === 'string') {
                                                const div = document.createElement('div');
                                                div.innerHTML = data;
                                                return div.textContent || div.innerText || '';
                                            }
                                            return data ?? '';
                                        }
                                    }
                                },
                                customize: function (xlsx) {
                                    const sheet = xlsx.xl.worksheets['sheet1.xml'];

                                    // بولد کردن ردیف اول (هدر)
                                    $('row:first c', sheet).attr('s', '2');

                                    // عرض خودکار برای تمام ستون‌ها (نسبی؛ اکسل خودش هندل می‌کند)
                                    const cols = $('col', sheet);
                                    if (cols.length === 0) {
                                        const columnCount = $('row:first c', sheet).length;
                                        for (let i = 0; i < columnCount; i++) {
                                            sheet.childNodes[0].appendChild($(`<col min="${i + 1}" max="${i + 1}" width="20" customWidth="1"/>`)[0]);
                                        }
                                    }
                                },
                                action: function (e, dt, button, config) {
                                    const filterRow = $('#myTable thead tr.filter-row').detach();
                                    $.fn.dataTable.ext.buttons.excelHtml5.action.call(this, e, dt, button, config);
                                    if (filterRow.length > 0) {
                                        $('#myTable thead').append(filterRow);
                                    }
                                }
                            },
                            {
                                extend: 'pdf',
                                text: '<i class="fas fa-file-pdf me-1"></i> PDF',
                                className: 'btn btn-outline-secondary',
                                exportOptions: {
                                    columns: [0, 1, 2, 3, 4],
                                    format: {
                                        header: function (data, columnIdx) {
                                            const th = $('#myTable thead tr:not(.filter-row)').first().find('th').eq(columnIdx);
                                            return $(th).text().trim();
                                        },
                                        body: function (data, row, column, node) {
                                            if (typeof data === 'string') {
                                                const div = document.createElement('div');
                                                div.innerHTML = data;
                                                return div.textContent || div.innerText || '';
                                            }
                                            return data ?? '';
                                        }
                                    }
                                },
                                customize: function (doc) {
                                    doc.pageMargins = [20, 20, 20, 20];
                                    doc.defaultStyle.fontSize = 10;

                                    // عنوان بالا
                                    doc.content.unshift({
                                        text: '---',
                                        style: 'header',
                                        alignment: 'center',
                                        margin: [0, 0, 0, 12]
                                    });

                                    // پیدا کردن جدول
                                    const tableNode = doc.content.find(item => item.table);
                                    if (tableNode) {
                                        tableNode.table.headerRows = 1;

                                        // 👉 تنظیم عرض جدول به full width
                                        tableNode.table.widths = Array(tableNode.table.body[0].length).fill('*');
                                    }

                                    doc.styles.tableHeader = {
                                        bold: true,
                                        fontSize: 11,
                                        color: 'black',
                                        fillColor: '#f1f1f1',
                                        alignment: 'center'
                                    };

                                    doc.styles.header = {
                                        fontSize: 14,
                                        bold: true
                                    };
                                },
                                action: function (e, dt, button, config) {
                                    const filterRow = $('#myTable thead tr.filter-row').detach();
                                    $.fn.dataTable.ext.buttons.pdfHtml5.action.call(this, e, dt, button, config);
                                    if (filterRow.length > 0) {
                                        $('#myTable thead').append(filterRow);
                                    }
                                }
                            }





                        ]
                    },
                    {
                        extend: 'print',
                        text: '<i class="fas fa-print me-1"></i> Print',
                        className: 'btn btn-outline-secondary',
                        exportOptions: {
                            columns: [0, 1, 2, 3, 4],  // ستون‌های غیرعکس
                            modifier: {
                                page: 'all'  // همه صفحات پرینت شوند
                            }
                        },
                        customize: function (win) {
                            $(win.document.body).css('font-family', "'Roboto', sans-serif");
                            $(win.document.body).css('font-size', '12pt');
                            $(win.document.body).find('table')
                                .addClass('table-bordered')
                                .css('width', '100%')
                                .css('border-collapse', 'collapse');

                            $(win.document.body).find('thead th').css({
                                'background-color': '#f1f1f1',
                                'color': '#000',
                                'font-weight': 'bold',
                                'border': '1px solid #ddd',
                                'padding': '8px',
                                'text-align': 'center',
                                'page-break-inside': 'avoid'
                            });

                            $(win.document.body).find('tbody td').css({
                                'border': '1px solid #ddd',
                                'padding': '8px',
                                'page-break-inside': 'avoid'
                            });

                            // اطمینان از اینکه هدر در هر صفحه پرینت شود:
                            $(win.document.body).find('thead').css('display', 'table-header-group');
                            $(win.document.body).find('tfoot').css('display', 'table-footer-group');
                        },
                        action: function (e, dt, node, config) {
                            var table = $('#myTable').DataTable();

                            // صفحه‌بندی را غیر فعال می‌کنیم (نمایش همه داده‌ها)
                            table.page.len(-1).draw();

                            // کمی زمان می‌دیم تا جدول به روز بشه
                            setTimeout(function () {
                                var tableCopy = $('#myTable').clone(true, true);
                                tableCopy.find('tr.filter-row').remove();

                                var printWindow = window.open('', '_blank');
                                printWindow.document.write(`
                                                            <!DOCTYPE html>
                                                            <html>
                                                            <head>
                                                                <title>گزارش دسته‌بندی‌ها</title>
                                                                <style>
                                                                    body { 
                                                                        font-family: 'Roboto', sans-serif;
                                                                        font-size: 12pt;
                                                                        margin: 0;
                                                                        padding: 10px;
                                                                    }
                                                                    table {
                                                                        width: 100%;
                                                                        border-collapse: collapse;
                                                                        margin-top: 10px;
                                                                    }
                                                                    thead th {
                                                                        background-color: #f1f1f1;
                                                                        color: #000;
                                                                        font-weight: bold;
                                                                        border: 1px solid #ddd;
                                                                        padding: 8px;
                                                                        text-align: center;
                                                                    }
                                                                    tbody td {
                                                                        border: 1px solid #ddd;
                                                                        padding: 8px;
                                                                    }
                                                                </style>
                                                            </head>
                                                            <body>
                                                                <h2 style="text-align:center; margin-bottom:20px;">گزارش دسته‌بندی‌ها</h2>
                                                                ${tableCopy.prop('outerHTML')}
                                                                <script>
                                                                    window.onload = function() {
                                                                        setTimeout(function() {
                                                                            window.print();
                                                                            window.close();
                                                                        }, 200);
                                                                    };
                                                                <\/script>
                                                            </body>
                                                            </html>
                                                        `);
                                printWindow.document.close();
                                // صفحه‌بندی را به حالت قبل بازگردان
                                table.page.len(10).draw();  // مقدار 10 را با مقدار پیش‌فرض صفحه‌بندی خودت عوض کن
                            }, 100);  // 100 میلی‌ثانیه تا جدول به روز شود، می‌توان بیشتر هم گذاشت اگر داده‌ها زیاد بود
                        }

                    },
                    {
                        extend: 'colvis',
                        text: '<i class="fas fa-columns me-1"></i> Column Visibility',
                        className: 'btn btn-outline-secondary'
                    }
                ],
                colReorder: true,
                initComplete: function () {
                    var thead = $('#myTable thead');
                    if (thead.find('tr.filter-row').length === 0) {
                        thead.append('<tr class="filter-row"></tr>');
                        this.api().columns().every(function () {
                            thead.find('tr.filter-row').append('<th></th>');
                        });
                    }
                },
                paging: true
            });

            let filtersBuilt = false;
            table.on('draw', function () {
                if (!filtersBuilt) {
                    buildFilters(table);
                    filtersBuilt = true;
                }
            });

            function buildFilters(table) {
                var api = table.api ? table.api() : table;
                var headerCells = $('#myTable thead tr.filter-row th');

                api.columns().every(function (colIdx) {
                    if (colIdx === 5) return; // ستون تصویر فیلتر ندارد

                    var column = this;
                    var headerCell = headerCells.eq(colIdx);

                    if (headerCell.children().length > 0) return;

                    var uniqueVals = [];
                    column.data().unique().sort().each(function (d) {
                        if (d != null && d !== undefined) {
                            var val = d.toString();
                            if (!uniqueVals.includes(val)) {
                                uniqueVals.push(val);
                            }
                        }
                    });

                    var html = `
                <button type="button" class="filter-toggle btn btn-sm btn-light mb-1">
                    <i class="fas fa-filter"></i> Filter
                </button>
                <div class="dropdown-menu p-2" style="display:none; position:absolute; background:#fff; border:1px solid #ccc; max-height:250px; overflow:auto; z-index:1000;">
                    <label><input type="checkbox" class="filter-checkbox-all" checked> Select All</label>
                    ${uniqueVals.map(val => `
                        <label style="display:block; margin-top:5px; cursor:pointer;">
                            <input type="checkbox" class="filter-checkbox" value="${val}" checked> ${val}
                        </label>
                    `).join('')}
                </div>
            `;

                    headerCell.html(html);

                    headerCell.find('.filter-toggle').off('click').on('click', function (e) {
                        e.preventDefault();
                        e.stopPropagation();
                        $('.dropdown-menu').not($(this).siblings('.dropdown-menu')).hide();
                        $(this).siblings('.dropdown-menu').toggle();
                    });

                    headerCell.find('.dropdown-menu').off('click').on('click', function (e) {
                        e.stopPropagation();
                    });

                    $(document).off('click.filters').on('click.filters', function () {
                        $('.dropdown-menu').hide();
                    });

                    headerCell.find('.filter-checkbox-all').off('change').on('change', function () {
                        var checked = $(this).is(':checked');
                        headerCell.find('.filter-checkbox').prop('checked', checked).trigger('change');
                    });

                    headerCell.find('.filter-checkbox').off('change').on('change', function () {
                        var allCount = headerCell.find('.filter-checkbox').length;
                        var checkedCount = headerCell.find('.filter-checkbox:checked').length;

                        headerCell.find('.filter-checkbox-all').prop('checked', allCount === checkedCount);

                        var selected = [];
                        headerCell.find('.filter-checkbox:checked').each(function () {
                            selected.push($(this).val());
                        });

                        if (selected.length === 0) {
                            column.search('').draw();
                        } else {
                            var regex = selected.map(function (v) {
                                return v.replace(/[.*+?^${}()|[\]\\]/g, '\\$&');
                            }).join('|');

                            column.search(regex, true, false, true).draw();
                        }
                    });
                });
            }

            $('#myTable tbody').on('click', 'tr', function () {
                var tableInstance = $('#myTable').DataTable();
                if ($(this).hasClass('selected')) {
                    $(this).removeClass('selected');
                } else {
                    tableInstance.$('tr.selected').removeClass('selected');
                    $(this).addClass('selected');
                }
            });
            function getCookie(name) {
                var value = `; ${document.cookie}`;
                var parts = value.split(`; ${name}=`);
                if (parts.length === 2) return parts.pop().split(';').shift();
                return '';
            }
        });
    </script>

</asp:Content>
