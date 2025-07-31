document.addEventListener("DOMContentLoaded", function () {
    // Admin Page Main Content
    const adminMainContent = document.getElementById("admin-main-content");

    // Viewer Page Main Content
    const viewerMainContent = document.getElementById("viewer-main-content");

    // Submenu Click Event Handler
    document.querySelectorAll(".submenu li").forEach(function (submenuItem) {
        submenuItem.addEventListener("click", function () {
            const itemId = submenuItem.id; // Get the ID of the clicked item

            // Determine the content to display based on the clicked submenu item
            let content = "";
            switch (itemId) {
                // Admin Page Submenu Items
                case "add-user":
                    content = `<h2>Add User</h2><button>Add</button><input type="text" placeholder="Enter User Name">`;
                    break;
                case "edit-user":
                    content = `<h2>Edit User</h2><button>Edit</button><input type="text" placeholder="Enter User ID">`;
                    break;
                case "delete-user":
                    content = `<h2>Delete User</h2><button>Delete</button><input type="text" placeholder="Enter User ID">`;
                    break;
                case "add-platform":
                    content = `<h2>Add Platform</h2><button>Add</button><input type="text" placeholder="Enter Platform Name">`;
                    break;
                case "edit-platform":
                    content = `<h2>Edit Platform</h2><button>Edit</button><input type="text" placeholder="Enter Platform ID">`;
                    break;
                case "delete-platform":
                    content = `<h2>Delete Platform</h2><button>Delete</button><input type="text" placeholder="Enter Platform ID">`;
                    break;

                // Viewer Page Submenu Items
                case "view-kpi":
                    content = `<h2>View KPI</h2><table><tr><th>Metric</th><th>Value</th></tr><tr><td>Performance</td><td>90%</td></tr></table>`;
                    break;
                case "update-kpi":
                    content = `<h2>Update KPI</h2><button>Update</button><input type="text" placeholder="Enter KPI Value">`;
                    break;
                case "track-platform":
                    content = `<h2>Track Platform</h2><button>Track</button><input type="text" placeholder="Enter Tracker ID">`;
                    break;
                case "view-tracker-logs":
                    content = `<h2>View Tracker Logs</h2><table><tr><th>Log ID</th><th>Description</th></tr><tr><td>1</td><td>Tracker Initialized</td></tr></table>`;
                    break;

                // Help Section
                case "faqs":
                    content = `<h2>FAQs</h2><p>Here are some frequently asked questions.</p>`;
                    break;
                case "contact-support":
                    content = `<h2>Contact Support</h2><p>Contact us at smartservices@eand.com</p>`;
                    break;

                default:
                    content = `<h2>Welcome</h2><p>Select a menu item to view details.</p>`;
                    break;
            }

            // Update the main-content div based on the page
            if (adminMainContent) {
                adminMainContent.innerHTML = content;
            } else if (viewerMainContent) {
                viewerMainContent.innerHTML = content;
            }
        });
    });
});