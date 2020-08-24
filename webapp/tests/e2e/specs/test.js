// https://docs.cypress.io/api/introduction/api.html

describe("My First Test", () => {
  it("Visits the app root url", () => {
    cy.visit("/");
    cy.contains("h1", "Welcome to Your Vue.js + TypeScript App");
  });

  it("Should display name of user", () => {
    const user = {
      name: "DevDaysOnline"
    };

    cy.server();
    cy.route("/security/user2", user);
    cy.visit("/");
    cy.contains("h2", "DevDaysOnline");
  });

  it("Should display name of user hard code", () => {
    cy.visit("/");
    cy.contains("h2", "Albert Weinert");
  });

  it("Should display name of user from request", () => {
    cy.server();
    cy.route("GET", "/security/user2").as("data");

    cy.visit("/");

    cy.wait("@data").then(({ responseJSON }) => {
      return cy.contains("h2", responseJSON.name);
    });
  });

});
