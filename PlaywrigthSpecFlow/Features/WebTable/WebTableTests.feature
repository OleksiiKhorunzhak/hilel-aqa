@ReusesFeatureDriver
@WebPageLogin

Feature: WebTableTest

  As a User, I want to add a new item to the web table,
  so that I can see the new item in the table,
  and I can delete and edit items.
  Scenario Outline: I see item in the table
	Given I am on DemoQA WebTable Page
	When I see the WebTable
	Then I see FirstName "<FirstName>" in a table
    And I see LastName "<LastName>" in a table
	Examples:
    | FirstName | LastName |
    | Cierra    | Vega     |
    | Alden     | Cantrell |
    | Kierra    | Gentry   |

 
   Scenario Outline: I add item to the table
	Given I am on DemoQA WebTable Page
	When I see the WebTable
	And I click Add Button
	And I set FirstName to "<FirstName>" 
    And I set LastName to "<LastName>" 
    And I set Email "<Email>" 
    And I set Age "<Age>" 
    And I set Salary "<Salary>" 
    And I set Department "<Department>"
    And I click Submit Button
     Then I see FirstName "<FirstName>" in a table
     And I see LastName "<LastName>" in a table
     And I see Email "<Email>" in a table
     And I see Age "<Age>" in a table
     And I see Salary "<Salary>" in a table
     And I see Department "<Department>" in a table

    Examples:
    | FirstName | LastName | Email              | Age | Salary | Department    |
    | Astolfo   | Rider    | astolfo.rider@e.com| 24  | 13800  | Fate/GO       |
    | Felix     | Argyle   | felix.argyle@e.com | 27  | 10600  | Re: Life      |
    | Hideyoshi | Kinoshita| hideyoshi.k@e.com  | 17  | 7600   | Baka&Test     |
    | Hideri    | Kanzaki  | hideri.k@e.com     | 19  | 10800  | Blend S       |
    | Izumi     | Asakawa  | izumi.asakawa@e.com| 21  | 11400  | Game of Life  |
    | Envy      | Sevenfold| envy.seven@e.com   | 26  | 12400  | FMA           |
    | Nagisa    | Shiota   | nagisa.shiota@e.com| 16  | 6800   | Assassination |
    | Erika     | Kudo     | erika.kudo@e.com   | 22  | 9300   | Durarara      |
    | Pico      | DeColette| pico.deco@e.com    | 28  | 12600  | Boku no Pico  |
    | Nitori    | Kawashiro| nitori.kawa@e.com  | 30  | 10200  | Touhou        |
    | Najimi    | Osana    | najimi.osana@e.com | 18  | 13000  | Komi Can't    |
    | Yoru      | Kurogane | yoru.kuro@e.com    | 25  | 13600  | Triage X      |
    | Suigetsu  | Hozuki   | suigetsu.h@e.com   | 31  | 14000  | Naruto        |
    | Kagerou   | Shoukiin | kagerou.s@e.com    | 20  | 8800   | EnSt          |
    | Saki      | Mitsuki  | saki.mitsuki@e.com | 24  | 14200  | Sweet Devil   |
    | Kaito     | Shindou  | kaito.shindou@e.com| 26  | 12600  | Sweet Devil   |
    | Ryu       | Hanazawa | ryu.hanazawa@e.com | 22  | 14400  | Sweet Devil   |
    | Luka      | Takahashi| luka.takaha@e.com  | 23  | 10400  | Sweet Devil   |
    | Kumagawa  | Misogi   | kumagawa.m@e.com   | 25  | 9800   | Medaka Box    |
    | Gottfried | Beckett  | gottfried.b@e.com  | 28  | 14800  | Gothic Lolita |
    | Chihiro   | Fujisaki | chihiro.f@e.com    | 27  | 9400   | Danganronpa   |
    | Haruka    | Nanase   | haruka.nanase@e.com| 22  | 12200  | Free!         |
    | Kaoru     | Hanayama | kaoru.hanaya@e.com | 30  | 11600  | Sakamoto      |
    | Ryouta    | Kise     | ryouta.kise@e.com  | 22  | 13400  | No Thank You  |
    | Nanako    | Amasawa  | nanako.amasa@e.com | 24  | 14200  | Girls,Girls   |
    | Leo       | Tsukinaga| leo.tsukinaga@e.com| 28  | 12800  | EnSt          |
    | Bright    | Noa      | bright.noa@e.com   | 23  | 10600  | Guilty Gear   |
    | Miki      | Takamine | miki.takami@e.com  | 25  | 14800  | Girls,Girls   |
    | Arata     | Matsunaga| arata.matsuna@e.com| 21  | 10800  | Girls,Girls   |
    | Saki      | Nagase   | saki.nagase@e.com  | 27  | 11600  | Girls,Girls   |
    | Ayame     | Inoue    | ayame.inoue@e.com  | 31  | 13000  | Himegoto      |
    | Shinya    | Kaito    | shinya.kaito@e.com | 30  | 10800  | Himegoto      |
    | Mutsuki   | Ito      | mutsuki.ito@e.com  | 21  | 11400  | Himegoto      |
    | Ruka      | Yamada   | ruka.yamada@e.com  | 32  | 12600  | Himegoto      |
    | Ryu       | Tano     | ryu.tano@e.com     | 28  | 13600  | Himegoto      |
    | Kotaro    | Saito    | kotaro.saito@e.com | 25  | 12400  | Himegoto      |
    | Takato    | Yagami   | takato.yagami@e.com| 23  | 14400  | Oniichan      |
    | Makoto    | Haruka   | makoto.haruka@e.com| 26  | 11800  | Uta no Prince |
    | Saiki     | Kiyoshi  | saiki.kiyoshi@e.com| 22  | 13600  | MyDearestLove |
    | Riku      | Aki      | riku.aki@e.com     | 24  | 14200  | Koi no Kimochi|
    | Kaoru     | Saki     | kaoru.saki@e.com   | 25  | 11600  | Dandelion     |
    | Yuuto     | Nakagawa | yuuto.nakaga@e.com | 27  | 12600  | Niku Saku     |
    | Tsubasa   | Hirose   | tsubasa.hiro@e.com | 22  | 10400  | CielNosurge   |
    | Yuto      | Shinohara| yuto.shino@e.com   | 30  | 14000  | Himegoto      |
    | Ryuichi   | Yamamoto | ryuichi.yama@e.com | 24  | 12200  | FemDream      |
    | Kanata    | Shinkai  | kanata.shink@e.com | 26  | 12800  | OtomeGame     |
    | Shun      | Takato   | shun.takato@e.com  | 22  | 11400  | MyGenderless  |
    | Daichi    | Akimoto  | daichi.akim@e.com  | 27  | 12100  | OtomeTeikou   |
    | Tsubasa   | Hanazawa | tsubasa.hanaz@e.com| 26  | 10600  | Junjou        |
    | Keiji     | Kuroda   | keiji.kurod@e.com  | 23  | 14800  | PrinceTennis  |
    
    
    Scenario Outline: I edit item in the table
	Given I am on DemoQA WebTable Page
    When I see the WebTable
	And I click Add Button
	And I set FirstName to "<FirstName>" 
    And I set LastName to "<LastName>" 
    And I set Email "<Email>" 
    And I set Age "<Age>" 
    And I set Salary "<Salary>" 
    And I set Department "<Department>"
    And I click Submit Button
    Then I see FirstName "<FirstName>" in a table
    
    When I am editing row number "4"
    And I set Salary "<New Salary>" 
    And I click Submit Button
    Then I see Salary "<New Salary>" in a table

     Examples:
    | FirstName | LastName | Email               | Age | Salary | Department | New Salary |
    | Astolfo   | Rider    | astolfo.rider@e.com | 24  | 13800  | Fate/GO    | 25000      |

     Scenario Outline: I delete row in the table
	Given I am on DemoQA WebTable Page
    
    When I see the WebTable
	And I click Add Button
	And I set FirstName to "<FirstName>" 
    And I set LastName to "<LastName>" 
    And I set Email "<Email>" 
    And I set Age "<Age>" 
    And I set Salary "<Salary>" 
    And I set Department "<Department>"
    And I click Submit Button
    Then I see FirstName "<FirstName>" in a table
    
    When I am deleting row number "4"
    Then I dont see Row "<FirstName>" in a table

     Examples:
    | FirstName | LastName | Email              | Age | Salary | Department    |
    | Astolfo   | Rider    | astolfo.rider@e.com| 24  | 13800  | Fate/GO       |
  