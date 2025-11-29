<h3>Please describe the differences between IAAS, PAAS and SAAS and give examples of each in a cloud platform of your choosing?</h3>
<p>
IAAS stands for Infrastructure As A Service. It essentially means a cloud provider is providing the hosting and virtual machines, etc. for any services of the client's choosing, but the client must do their own server setup and installations of software. Azure IaaS is an example.
</p>
<p>
PAAS stands for Platform As A Service. This means that a cloud provider has their own suite of software options and clients can register licenses to use this software through the internet. When a user registers a license, they can create organizations, tenants, etc. using an administration interface. One such example is Sitecore XM Cloud.
</p>
<p>
SAAS stands for Software As A Service. This refers to one single piece of software which is accessed by end users through the web, rather than running it on their own computer. One such example is the online offering for TurboTax. Users do not need to install it, they can file their taxes completely through the web interface.
</p>
<h3>What are the considerations of a build or buy decision when planning and choosing software?</h3>
<p>
Build or buy refers to the decision, given business needs and requirements, to hire a development team and create their needed solution from scratch, or to purchase a pre-built piece of software and configure it to meet their needs. In my experience, this comes down to a few things:
	<ul>
		<li>
			Connectivity to current business-critical systems
		</li>
		<li>
			Information security - does the business allow a third-party provider to host their data or does it need to stay in-house
		</li>
		<li>
			Existing case studies where similar projects have been done, and whether they built or bought
		</li>
		<li>
			Is a purchased solution able to be branded to the company's liking
		</li>
	</ul>
</p>
<h3>What are the foundational elements and considerations when developing a serverless architecture? </h3>
<p>
	I don't generally develop in a serverless architecture, as a backend .NET developer, so any answer I could give to this would just be something I looked up.
</p>
<h3>Please describe the concept of composition over inheritance </h3>
<p>
	Inheritance refers to a class that's based on another class, and gets a base of behaviors and functionality from that other class. An example would be an Apple class that inherits from a Fruit class.
</p>
<p>
	Composition refers to a class containing member properties that are instances of other classes. One example could be the Elevator class in this repo having a Floors property.
</p>
<p>
	Composition over inheritance posits that objects should be designed based on what they can do, rather than what they are. Inheritance can be rigid and force you to gain functionality you won't need, whereas composition allows you to choose what functionality each class really needs.
</p>
<h3>Describe a design pattern you’ve used in production code. What was the pattern? How did you use it? Given the same problem how would you modify your approach based on your experience?</h3>
<p>
	I once had an assignment to integrate a school activity registration site with a third-party system (called Privit) and create a single sign-on from the original site to Privit. The idea was that the user would load their page as normal, and then instead of seeing their normal link to register, they'd see a link to Privit. Clicking the link would bring them to Privit where they'd find an existing account already created, and be signed into it.
</p>
<p>
	I used Privit's APIs to read the user's account information and send it to them, and when the call completed, the link would appear. In the meantime the user saw a spinner next to each activity. I was making an asynchronous call and waiting for the response. This led to some users waiting up to 10 seconds, and confusion as to what was happening.
</p>
<p>
	In the future I might instead defer this work to a batch service so that the user would not have to wait while actively using the site, and instead maybe just show a maintenance window message during the batch job.
</p>