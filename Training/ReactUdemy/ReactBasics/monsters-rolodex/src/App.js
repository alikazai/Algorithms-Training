import "./App.css";
import { Component } from "react";
import CardList from "./components/card-list/card-list.component";
import SearchBox from "./components/search-box/search-box.component";

class App extends Component {
  constructor() {
    super();
    this.state = {
      monsters: [],
      searchField: "",
    };
  }

  componentDidMount() {
    fetch("https://jsonplaceholder.typicode.com/users")
      .then((res) => res.json())
      .then((users) =>
        this.setState(
          () => {
            return { monsters: users };
          },
          () => {
            console.log(this.state);
          }
        )
      );
  }

  onSearchChange = (event) => {
    const searchField = event.target.value.toLocaleLowerCase();
    this.setState(() => {
      return { searchField };
    });
  };

  render() {
    const filteredMonsters = this.state.monsters.filter((m) => m.name.toLocaleLowerCase().includes(this.state.searchField));
    return (
      <div className="App">
        <SearchBox onChangeHandler={this.onSearchChange} placeholder="search monsters" className="search-box" />
        <CardList monsters={filteredMonsters} />
      </div>
    );
  }
}

export default App;

// https://jsonplaceholder.typicode.com/users
