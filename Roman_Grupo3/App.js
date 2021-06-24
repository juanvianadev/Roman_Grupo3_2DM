import React from 'react';
import { StyleSheet, View } from 'react-native';
import { NavigationContainer } from '@react-navigation/native';
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';

import Listar from './src/screens/Listar';
import Cadastrar from './src/screens/Cadastrar';
import { Component } from 'react/cjs/react.production.min';

const bottomTab = createBottomTabNavigator

export default class App extends Component{
  render(){
    return(
      <NavigationContainer>
        <bottomTab.Navigator>
          <bottomTab.Screen name="Listar" component={Listar}/>
          <bottomTab.Screen name="Cadastar" component={Cadastrar}/>
          {/* <bottomTab.Screen name="Login" component={Login}/> */}
        </bottomTab.Navigator>
      </NavigationContainer>
    );
  }
}
