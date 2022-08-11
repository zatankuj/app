module.exports = {
  env: {
    browser: true,
    es2021: true,
  },
  extends: [
    "plugin:react/recommended",
    "plugin:prettier/recommended",
    "standard",
  ],
  parser: "@typescript-eslint/parser",
  parserOptions: {
    ecmaFeatures: {
      jsx: true
    },
    ecmaVersion: "latest",
    sourceType: "module",
  },
  plugins: ["react", "react-native", "@typescript-eslint"],
  rules: {
    "prettier/prettier": "error",
    "arrow-body-style": "off",
    "prefer-arrow-callback": "off",
    "no-use-before-define": "off",
    "import/no-duplicates": "off",
    "space-before-function-paren": "off",
  }
}
