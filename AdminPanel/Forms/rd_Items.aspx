<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rd_Items.aspx.cs" MasterPageFile="~/Site.Master" Inherits="AdminPanel.Forms.rd_Items" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="card mt-4">
        <div class="card-body">
            <div class="row mb-3">
                <!-- Column 3: Category Dropdown -->
                <div class="col-md-3">
                    <div class="dropdown-wrapper" style="position: relative;">
                        <select id="ddlCategory" class="form-select" style="min-width: 200px;"></select>
                        <!-- Spinner overlay -->
                        <div id="loadingSpinner" style="display: none; position: absolute; top: 0; left: 0; right: 0; bottom: 0; background: rgba(255, 255, 255, 0.6); z-index: 10; display: flex; align-items: center; justify-content: center; pointer-events: none;">
                            <div class="spinner-border text-primary" role="status" style="width: 1.5rem; height: 1.5rem;">
                                <span class="visually-hidden">Loading...</span>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- Column 1: Search Input 1 -->
                <div class="col-md-3">
                    <input type="text" id="txtSearch1" class="form-control" placeholder="Item name">
                </div>

                <!-- Column 2: Search Input 2 -->
                <div class="col-md-3">
                    <input type="text" id="txtSearch2" class="form-control" placeholder="Barcode">
                </div>



                <!-- Column 4: Search Button -->
                <div class="col-md-3 d-flex align-items-start gap-2">
                    <button id="btnSearch" class="btn btn-primary">
                        <i class="fas fa-search me-1"></i>Search
                    </button>
                    <button id="btnAddNewItem" class="btn btn-success" type="button">
                        <i class="fas fa-plus me-1"></i>Add New Item
                    </button>

                </div>

            </div>


            <div class="row mt-8">
                <div class="col-12">
                    <div style="overflow-x: auto;">
                        <table id="myTable" class="display nowrap table table-bordered" style="width: 100%">
                            <thead>
                                <tr class="main-header">
                                    <th>#</th>
                                    <th>Edit</th>
                                    <th>Title</th>
                                    <th>Display Name</th>
                                    <th>Category</th>
                                    <th>Price</th>
                                    <th>Tax Rate</th>
                                    <th>Color</th>
                                    <th>Image</th>
                                    <th>Barcode</th>
                                    <%--<th>SKU Code</th>--%>
                                    <%--<th>Modifier Group</th>--%>
                                    <%--<th>Visible</th>--%>
                                    <th>Item Size</th>
                                    <th>Printer</th>
                                    <%--<th>KDS</th>--%>
                                </tr>
                            </thead>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <style>
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
    <script src="../SilkJS/rd_items.js"></script>
</asp:Content>









