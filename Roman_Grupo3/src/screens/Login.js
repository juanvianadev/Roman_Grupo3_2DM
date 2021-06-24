// import { StatusBar } from 'expo-status-bar';
import React, { Component } from 'react';
import { FlatList, Image, StyleSheet, Text, View } from 'react-native';

export default class App extends Component{

  render(){
    return(
      <View style={styles.main}>        
        <text>Login</text>
      </View>
    );
  }
}

const styles = StyleSheet.create({
  main: {
    flex: 1,
    backgroundColor: '#fff',
    alignItems: 'center',
    justifyContent: 'center',
  },
});
