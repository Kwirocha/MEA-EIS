﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default2.aspx.vb" Inherits="Default2" %>

<!DOCTYPE html>
<!--[if IE 9]>			<html class="ie ie9"> <![endif]-->
<!--[if gt IE 9]><!-->	<html> <!--<![endif]-->
<head>
	<!-- Basic -->
	<meta charset="utf-8">
	<title>Jets - Home page</title>
	<meta name="keywords" content="HTML5 Template" />
	<meta name="description" content="Jets - Responsive HTML5 Template">
	<meta name="author" content="funcoders.com">

	<!-- Favicons -->
	<link rel="shortcut icon" type='image/x-icon' href="img/favicon/favicon.ico">
	<link rel="apple-touch-icon-precomposed" sizes="144x144" href="img/favicon/fapple-touch-icon-144x144-precomposed.png">
	<link rel="apple-touch-icon-precomposed" sizes="114x114" href="img/favicon/fapple-touch-icon-114x114-precomposed.png">
	<link rel="apple-touch-icon-precomposed" sizes="72x72" href="img/favicon/fapple-touch-icon-72x72-precomposed.png">
	<link rel="apple-touch-icon-precomposed" href="img/favicon/fapple-touch-icon-precomposed.png">

	<!-- Mobile Metas -->
	<meta name="viewport" content="width=device-width, initial-scale=1.0">

	<!-- Bootstrap CSS -->
	<link rel="stylesheet" href="css/library/bootstrap/bootstrap.min.css" />

	<!-- AWESOME and ICOMOON fonts -->
	<link rel="stylesheet" href="css/fonts/awesome/css/font-awesome.css">
	<link rel="stylesheet" href="css/fonts/icomoon/style.css">

	<!-- Open Sans fonts -->
	<link rel="stylesheet"  href="http://fonts.googleapis.com/css?family=Open+Sans:300italic,400italic,600italic,700italic,800italic,400,300,600,700,800">

	<!-- Theme CSS -->
	<link rel="stylesheet" href="css/theme.min.css">
	<link rel="stylesheet" href="css/theme-elements.min.css">
	<link rel="stylesheet" href="css/color/orange.css">

	<link rel="stylesheet" href="css/library/animate/animate.min.css">

	<!-- Your styles -->
	<link rel="stylesheet" href="css/styles.css">
</head>

<body class="index">

	<aside class="side-options side-options-right" id="language-options">
		<div class="side-options-heading">

			<a href="#"><span class="current-language">EN</span>Language</a>

		</div><!-- .side-options-heading -->
		<div class="side-options-content">

			<ul class="language-list">
				<li><a class="current" href="EN">English</a></li>
				<li><a href="SP">Spanish</a></li>
				<li><a href="RUS">Russian</a></li>
				<li><a href="FR">French</a></li>
			</ul>

		</div><!-- .side-options-content -->
	</aside><!-- .side-options -->

	<header id="header">
		<aside class="topbar">
			<div class="container">

				<ul class="touch">
					<li>
						<img src="img/phone.png" alt="Phone" title="Phone">
						<p>1800-2233-4455<br />1800-6677-8899</p>
					</li>
					<li>
						<img src="img/mail.png" alt="Mail" title="Mail">
						<p><a href="mailto:victoria@yoursite.com">victoria@yoursite.com</a><br /><a href="mailto:macdonald@yoursite.com">macdonald@yoursite.com</a></p>
					</li>
					<li>
						<img src="img/map.png" alt="Map" title="Map">
						<p>322 Victoria Street<br />Darlinghurst NSW 2010</p>
					</li>
				</ul><!-- .touch -->

				<ul class="user-nav">
					<li><a href="#login-register" data-toggle="modal" title="Log in">Log In</a></li>
					<li><a href="#login-register" data-toggle="modal" title="Create an account" class="btn">Register</a></li>
				</ul><!-- .user-nav -->

				<ul class="user-nav" style="display:none">
					<li><a href="#" title="John Doe"></a></li>
					<li><a href="#" title="John Doe">John Doe</a> | </li>
					<li><a href="#" title="Log Out">Log out</a></li>
				</ul><!-- .user-nav -->

				<ul class="social">
					<li><a href="#" class="dribbble"></a></li>
					<li><a href="#" class="pinterest"></a></li>
					<li><a href="#" class="facebook"></a></li>
					<li><a href="#" class="twitter"></a></li>
					<li><a href="#" class="google"></a></li>
				</ul><!-- .social -->

			</div><!-- .container -->
		</aside><!-- .topbar -->
		<div class="navbar megamenu-width">
			<div class="container">

				<aside id="main-search">
					<form action="#" method="GET">
						<a href="#" class="close"><i class="icomoon-close"></i></a>
						<div class="form-field">
							<div class="placeholder">
								<label for="query">search on site...</label>
								<input class="form-control" type="text" name="query" id="query" />
							</div>
						</div>
					</form>
				</aside><!-- #main-search -->

				<div class="navbar-inner">

					<a href="index.html" class="logo">
						<img src="img/logo.png" alt="Jets">
					</a><!-- .logo -->

					<ul id="mobile-menu">
						<li><a href="#login-register" data-toggle="modal" title="Log in">Log In</a></li>
						<li><a href="#login-register" data-toggle="modal" title="Create an account">Register</a></li>
						<li>
							<button class="navbar-toggle" type="button" data-toggle="collapse" data-target=".navbar-collapse">
								<i class="fa fa-reorder"></i>
							</button>
						</li>
						<li><a class="btn-search" href="#"><i class="fa fa-search"></i></a></li>
					</ul><!-- #mobile-menu -->

					<ul id="main-menu" class="collapse navbar-collapse nav slide custom">
						<li class='active'><a href="index.html">Home<i class="carret"></i><span>Let's Start here</span></a>
							<ul class="dropdown">
								<li class='active'><a href="index.html">Default Home Page</a></li>
								<li><a href="index-2.html">Home Page Stye 2</a></li>
								<li><a href="index-3.html">Home Page Stye 3</a></li>
								<li><a href="index-informational.html">Home Page Informational</a></li>
								<li><a href="index-one-page.html">One Page Home</a></li>
							</ul>
						</li>
						<li class="megamenu"><a href="#">Megamenu 1<i class="carret"></i><span>With category</span></a>
							<ul class="dropdown megamenu-category">
								<li>
									<div class="row">
										<div class="col-md-3">

											<nav class="category-nav">
												<ul>
													<li class="current"><a href="#">Category with list</a></li>
													<li><a href="#">Category with groups</a></li>
													<li><a href="#">Category mixed</a></li>
												</ul>
											</nav><!-- .category-nav" -->

										</div><!-- .col-md-3 -->
										<div class="col-md-9">

											<div class="category-content">
												<div class="current">

													<div class="title">
														<h4>Category with list</h4>
													</div><!-- .title -->

													<div class="text">
														<p><i>Pellentesque cursus elit sed mauris vestibulum congue. Proin blandit sagittis convallis.</i></p>
													</div><!-- .text -->
													<hr />
													<div class="row">
														<div class="col-sm-6">

															<div class="title">
																<h5>Sub category title</h5>
															</div><!-- .title -->
															<ul class="default">
																<li><a href="#">Phasellus vel</a>
																	<ul class="plus">
																		<li><a href="#">Maecenas malesuada</a></li>
																		<li><a href="#">Nunc a vestibulum</a></li>
																	</ul>
																</li>
																<li><a href="#">Nullam</a></li>
																<li><a href="#">Duis sodales eget</a></li>
															</ul>
															<div class="title">
																<h5>Sub category title</h5>
															</div><!-- .title -->
															<ul class="default">
																<li><a href="#">Cibendum</a></li>
																<li><a href="#">Nullam eleifend</a></li>
																<li><a href="#">Vivamus</a></li>
															</ul>

														</div><!-- .col-sm-6 -->
														<div class="col-sm-6">

															<div class="title">
																<h5>Sub category title</h5>
															</div><!-- .title -->
															<ul class="default">
																<li><a href="#">Nunc cursus</a></li>
																<li><a href="#">Pellentesque</a>
																	<ul class="circle">
																		<li><a href="#">Vestibulum</a></li>
																	</ul>
																</li>
																<li><a href="#">Mauris faucibus</a></li>
																<li><a href="#">Aenean</a>
																	<ul class="check">
																		<li><a href="#">Fusce</a></li>
																		<li><a href="#">Fermentum </a></li>
																		<li><a href="#">Velit porta</a></li>
																	</ul>
																</li>
																<li><a href="#">Curabitur</a></li>
																<li><a href="#">Cras facilisis</a></li>
															</ul>

														</div><!-- .col-sm-6 -->
													</div><!-- .row -->
												</div>
												<div>
													<div class="title">
														<h4>Category with groups</h4>
													</div><!-- .title -->
													<div class="text">
														<p><i>Maecenas ac tortor malesuada, tristique purus nec, pulvinar enim. Vivamus suscipit ultricies ultrices. Morbi egestas nec elit non luctus.</i></p>
													</div><!-- .text -->
													<hr />
													<div class="row">
														<div class="col-sm-4">

															<a href="#">
																<div class="iconbox">
																	<div class="iconbox-heading">
																		<div class="icon">
																			<img src="uploads/images/icons/icon.jpg" alt="Icon">
																		</div>
																		<div class="title">
																			<h4><h5>Cras pretium</h5></h4>
																		</div>
																	</div><!-- .iconbox-heading -->
																</div><!-- .iconbox -->
															</a>

														</div><!-- .col-sm-4 -->
														<div class="col-sm-4">

															<a href="#" class="iconbox">
																<div class="iconbox">
																	<div class="iconbox-heading">
																		<div class="icon">
																			<img src="uploads/images/icons/icon.jpg" alt="Icon">
																		</div>
																		<div class="title">
																			<h4><h5>Cras pretium</h5></h4>
																		</div>
																	</div><!-- .iconbox-heading -->
																</div><!-- .iconbox -->
															</a>

														</div><!-- .col-sm-4 -->
														<div class="col-sm-4">

															<a href="#" class="iconbox">
																<div class="iconbox">
																	<div class="iconbox-heading">
																		<div class="icon">
																			<img src="uploads/images/icons/icon.jpg" alt="Icon">
																		</div>
																		<div class="title">
																			<h4><h5>Morbi consequat</h5></h4>
																		</div>
																	</div><!-- .iconbox-heading -->
																</div><!-- .iconbox -->

															</a>

														</div><!-- .col-sm-4 -->
													</div><!-- .row -->
													<div class="row">
														<div class="col-sm-4">

															<a href="#">
																<div class="iconbox">
																	<div class="iconbox-heading">
																		<div class="icon">
																			<img src="uploads/images/icons/icon.jpg" alt="Icon">
																		</div>
																		<div class="title">
																			<h4><h5>Fermentume</h5></h4>
																		</div>
																	</div><!-- .iconbox-heading -->
																</div><!-- .iconbox -->
															</a>

														</div><!-- .col-sm-4 -->
														<div class="col-sm-4">

															<a href="#">
																<div class="iconbox">
																	<div class="iconbox-heading">
																		<div class="icon">
																			<img src="uploads/images/icons/icon.jpg" alt="Icon">
																		</div>
																		<div class="title">
																			<h4><h5>In hac habitasse</h5></h4>
																		</div>
																	</div><!-- .iconbox-heading -->
																</div><!-- .iconbox -->

															</a><!-- .iconbox -->

														</div><!-- .col-sm-4 -->
														<div class="col-sm-4">

															<a href="#">
																<div class="iconbox">
																	<div class="iconbox-heading">
																		<div class="icon">
																			<img src="uploads/images/icons/icon.jpg" alt="Icon">
																		</div>
																		<div class="title">
																			<h4><h5>Aliquam erat</h5></h4>
																		</div>
																	</div><!-- .iconbox-heading -->
																</div><!-- .iconbox -->

															</a>

														</div><!-- .col-sm-4 -->
													</div><!-- .row -->
												</div>
												<div>
													<div class="title">
														<h4>Category mixed</h4>
													</div><!-- .title -->
													<div class="text">
														<p><i> Vivamus suscipit magna ut lorem cursus, vel elementum neque condimentum. Integer sit amet malesuada mi. Ut non sollicitudin leo, vel convallis lacus.</i></p>
													</div><!-- .text -->
													<hr />
													<div class="row">
														<div class="col-sm-4">

															<a href="#">
																<div class="iconbox">
																	<div class="iconbox-heading">
																		<div class="icon">
																			<img src="uploads/images/icons/icon.jpg" alt="Icon">
																		</div>
																		<div class="title">
																			<h4><h5>Vestibulum</h5></h4>
																		</div>
																	</div><!-- .iconbox-heading -->
																</div><!-- .iconbox -->

															</a>

														</div><!-- .col-sm-4 -->
														<div class="col-sm-4">

															<a href="#">
																<div class="iconbox">
																	<div class="iconbox-heading">
																		<div class="icon">
																			<img src="uploads/images/icons/icon.jpg" alt="Icon">
																		</div>
																		<div class="title">
																			<h4><h5>Nulla nec consequat enim</h5></h4>
																		</div>
																	</div><!-- .iconbox-heading -->
																</div><!-- .iconbox -->

															</a>

														</div><!-- .col-sm-4 -->
														<div class="col-sm-4">

															<a href="#">
																<div class="iconbox">
																	<div class="iconbox-heading">
																		<div class="icon">
																			<img src="uploads/images/icons/icon.jpg" alt="Icon">
																		</div>
																		<div class="title">
																			<h4><h5>Donec sit</h5></h4>
																		</div>
																	</div><!-- .iconbox-heading -->
																</div><!-- .iconbox -->

															</a>

														</div><!-- .col-sm-4 -->
													</div><!-- .row -->
													<hr />
													<div class="row">
														<div class="col-sm-6">

															<div class="title">
																<h5>Sub category title</h5>
															</div><!-- .title -->
															<ul class="default">
																<li><a href="#">Duis sodales eget</a></li>
																<li><a href="#">Phasellus vel</a>
																	<ul class="dash">
																		<li><a href="#">Maecenas malesuada</a></li>
																		<li><a href="#">Nunc a vestibulum</a></li>
																	</ul>
																</li>
															</ul>

														</div><!-- .col-sm-6 -->
														<div class="col-sm-6">

															<div class="title">
																<h5>Sub category title</h5>
															</div>
															<ul class="default">
																<li><a href="#">Donec congue</a></li>
																<li><a href="#">Pellentesque</a></li>
																<li><a href="#">Fusce</a></li>
																<li><a href="#">Velit porta</a></li>
															</ul>

														</div><!-- .col-sm-6 -->
													</div><!-- .row -->
												</div>
											</div><!-- .category-content -->

										</div><!-- .col-md-9 -->
									</div>
								</li>
							</ul><!-- .megamenu-category -->
						</li>
						<li class="megamenu"><a href="#">Megamenu 2<i class="carret"></i><span>With content</span></a>
							<ul class="dropdown">
								<li>
									<div class="row">
										<div class="col-sm-4">

											<div class="widget">
												<div class="widget-heading">

													<div class="title title-main">
														<h5>Latest from Blog</h5>
													</div>

												</div><!-- .widget-heading -->
												<div class="widget-content">

													<section class="posts">
														<article class="post post-mini post-type-text devider-top">
															<div class="post-heading">

																<div class="thumbnail">
																	<a class="link" href="blog-single.html">
																		<span class="btn btn-icon-link"></span>
																		<img src="uploads/images/content/image_SQ.jpg" alt="Image">
																	</a>
																</div><!-- .thumbnail -->

															</div><!-- .post-heading -->
															<div class="post-content">

																<div class="title">
																	<h2 class="h5"><a href="blog-single.html">Sed ut perspiciatis unde omnis iste</a></h2>
																</div><!-- .title -->

															</div><!-- .post-content -->
														</article><!-- .post -->
														<article class="post post-mini post-type-music devider-top">
															<div class="post-heading">

																<div class="thumbnail">
																	<a class="link" href="blog-single.html">
																		<span class="btn btn-icon-link"></span>
																		<img src="uploads/images/content/image_SQ.jpg" alt="Image">
																	</a>
																</div><!-- .thumbnail -->

															</div><!-- .post-heading -->
															<div class="post-content">

																<div class="title">
																	<h2 class="h5"><a href="blog-single.html">Consequuntur magni dolores</a></h2>
																</div><!-- .title -->

															</div><!-- .post-content -->
														</article><!-- .post -->
													</section>

												</div><!-- .widget-content -->
											</div><!-- .widget -->

										</div><!-- .col-sm-4 -->
										<div class="col-sm-4">

											<div class="widget">
												<div class="widget-heading">

													<div class="title title-main">
														<h5>Find us on Google Map</h5>
													</div><!-- .title -->

												</div><!-- .widget-heading -->
												<div class="widget-content">
													<iframe class="google-iframe-map" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" src="https://maps.google.com.ua/maps?t=m&amp;q=322+Victoria+Street+Darlinghurst+NSW+2010&amp;ie=UTF8&amp;hq=&amp;hnear=322+Victoria+St,+Darlinghurst+New+South+Wales+2010,+%D0%90%D0%B2%D1%81%D1%82%D1%80%D0%B0%D0%BB%D1%96%D1%8F&amp;ll=-33.877969,151.222343&amp;spn=0.010689,0.036478&amp;z=14&amp;iwloc=A&amp;output=embed"></iframe>
												</div><!-- .widget-content -->
											</div><!-- .widget -->

										</div><!-- .col-sm-4 -->
										<div class="col-sm-4">

											<div class="widget">
												<div class="widget-heading">

													<div class="title title-main">
														<h5>Simple text widget</h5>
													</div><!-- .title -->

												</div><!-- .widget-heading -->
												<div class="widget-content">

													<div class="text">
														<p>Aliquet blandit, tellus libero scelerisque odio, sit amet tincidunt est leo eget urna.Donec tincidunt neque nulla. Arcu ut aliquet blandit.</p>
														<p>Praesent quam nibh, viverra vitae tempus at Morbi accumsan, arcu ut aliquet onec tincidunt neque nulla. Tellus libero scelerisque odio, sit amet tincidunt.</p>
														<p class="text-right"><a href="#" class="btn">Read more</a></p>
													</div><!-- .text -->

												</div><!-- .widget-content -->
											</div><!-- .widget -->

										</div><!-- .col-sm-4 -->
									</div><!-- .row -->
								</li>
							</ul><!-- .megamenu -->
						</li>
						<li><a href="#">Features<i class="carret"></i><span>Out of the Box</span></a>
							<ul class="dropdown">
								<li><a href="features-header-default.html">Layout Header<i class="carret"></i></a>
									<ul class="dropdown">
										<li><a href="features-header-default.html">Default</a></li>
										<li><a href="features-header-1.html">Style 1</a></li>
										<li><a href="features-header-2.html">Style 2</a></li>
										<li><a href="features-header-3.html">Style 3</a></li>
									</ul>
								</li>
								<li><a href="features-menu-default.html">Drop Down Menu<i class="carret"></i></a>
									<ul class="dropdown">
										<li><a href="features-menu-default.html">Default</a></li>
										<li><a href="features-menu-custom.html">Custom</a></li>
									</ul>
								</li>
								<li><a href="features-grid.html">Grid System</a></li>
								<li><a href="features-typography.html">Typography</a></li>
								<li><a href="features-miscellaneous.html">Miscellaneous</a></li>
								<li><a href="#">Icons<i class="carret"></i></a>
									<ul class="dropdown">
										<li><a href="features-iconawesome.html">Awesome Font</a></li>
										<li><a href="features-iconicomoon.html">Iconmoon Font</a></li>
									</ul>
								</li>
								<li><a href="features-animation.html">Animation</a></li>
							</ul>
						</li>
						<li><a href="#">Shortcodes<i class="carret"></i><span>Page elements</span></a>
							<ul class="dropdown">
								<li><a href="shortcodes-iconbox.html">Icon Box</a></li>
								<li><a href="shortcodes-teaser.html">Teaser</a></li>
								<li><a href="shortcodes-alerts-messages.html">Alerts and Messages</a></li>
								<li><a href="shortcodes-call2action.html">Call to action</a></li>
								<li><a href="shortcodes-testimonial.html">Testimonial</a></li>
								<li><a href="shortcodes-tab.html">Tab</a></li>
								<li><a href="shortcodes-accordion.html">Accordion</a></li>
								<li><a href="shortcodes-slider.html">Slider</a></li>
								<li><a href="shortcodes-carousel.html">Carousel</a></li>
								<li><a href="shortcodes-pricingtables.html">Pricing Tables</a></li>
								<li><a href="shortcodes-multimedia.html">Multimedia</a></li>
							</ul>
						</li>
						<li><a href="#">Portfolio<i class="carret"></i><span>Our Works</span></a>
							<ul class="dropdown">
								<li><a href="portfolio-4col.html">Portfolio 4 columns</a></li>
								<li><a href="portfolio-3col.html">Portfolio 3 columns</a></li>
								<li><a href="portfolio-2col.html">Portfolio 2 columns</a></li>
								<li><a href="portfolio-full.html">Portfolio full width</a></li>
								<li><a href="portfolio-full-no-margins.html">Portfolio full width (no margins)</a></li>
								<li><a href="portfolio-full-no-animated.html">Portfolio full width (no animation)</a></li>
								<li><a href="portfolio-single.html">Single Project</a></li>
							</ul>
						</li>
						<li><a href="#">Pages<i class="carret"></i><span>Inbuilt Templates</span></a>
							<ul class="dropdown">
								<li><a href="page-team.html">Our Team</a></li>
								<li><a href="page-team-member.html">Team member</a></li>
								<li><a href="page-services.html">Services</a></li>
								<li><a href="page-faq.html">FAQ</a></li>
								<li><a href="page-about.html">About Us</a></li>
								<li><a href="page-404.html">404 Page</a></li>
								<li><a href="page-login-register.html">Login / Register Page</a></li>
								<li><a href="blog-default.html">Blog<i class="carret"></i></a>
									<ul class="dropdown">
										<li><a href="blog-default.html">Blog (default)</a></li>
										<li><a href="blog-thumbs.html">Blog (thumbs)</a></li>
										<li><a href="blog-grid.html">Blog (grid)</a></li>
										<li><a href="blog-single.html">Single post</a></li>
									</ul>
								</li>
								<li><a href="contact.html">Contact<i class="carret"></i></a>
									<ul class="dropdown">
										<li><a href="contact.html">Contact</a></li>
										<li><a href="contact-2.html">Contact Style 2</a></li>
									</ul>
								</li>
							</ul>
						</li>
						<li class="search-nav">
							<a href="#" class="btn-search"><i class="fa fa-search"></i></a>
						</li>
					</ul><!-- #main-menu -->

				</div><!-- .navbar-inner -->

			</div><!-- .container -->
		</div><!-- .navbar -->
	</header><!-- #header -->

	<div class="page-slider-wrap">
		<div id="page-slider" >
			<ul>
				<li data-transition="zoomout" data-masterspeed="1300">

					<!-- MAIN IMAGE -->
					<img src="uploads/images/slides/1/bg.jpg"  alt="bg"  data-bgfit="cover" data-bgposition="center center" data-bgrepeat="no-repeat">

					<!-- LAYER NR. 1 -->
					<div class="tp-caption slider-title text-right sfl" data-x="right" data-hoffset="-15" data-y="top" data-voffset="130" data-speed="1000" data-start="500" data-easing="Back.easeInOut" data-endspeed="300" style="color:#083f68">Jets waitng for you</div>

					<!-- LAYER NR. 2 -->
					<div class="tp-caption slider-sub-title text-right sfl" data-x="right" data-hoffset="-15" data-y="center" data-speed="1100" data-start="600" data-easing="Back.easeInOut" data-endspeed="300" style="color:#ec5753">Increase your productivity, business<br/> and status with this awesome theme</div>

					<!-- LAYER NR. 3 -->
					<a href="#" class="tp-caption sfb btn btn-big text-right" data-x="right" data-hoffset="-15" data-y="bottom" data-voffset="-130" data-speed="1000" data-start="700" data-easing="Back.easeInOut" data-endspeed="300" style="color:#52c7e5">Read More</a>

				</li>
				<li data-transition="zoomout" data-masterspeed="1300">

					<!-- MAIN IMAGE -->
					<img src="uploads/images/slides/2/bg.jpg"  alt="bg"  data-bgfit="cover" data-bgposition="center center" data-bgrepeat="no-repeat">

					<!-- LAYER NR. 1 -->
					<div class="tp-caption slider-title text-center sft" data-x="center" data-y="center" data-voffset="-140" data-speed="1000" data-start="500" data-easing="Power1.easeOut" data-endspeed="300" data-endeasing="Power1.easeIn" style="color:#756670">Discover all new!</div>

					<!-- LAYER NR. 2 -->
					<div class="tp-caption slider-sub-title text-center sfl" data-x="center" data-y="center" data-speed="800" data-start="600" data-easing="Power1.easeOut" data-endspeed="300" data-endeasing="Power1.easeIn" style="color:#062234">We have collected the most modern web<br /> technologies added a little bit of our love<br /> painted with bright colors and created Jets</div>

					<!-- LAYER NR. 3 -->
					<a href="#" class="tp-caption sfb btn btn-big" data-x="center" data-y="center" data-voffset="140" data-speed="1000" data-start="700" data-easing="Power4.easeOut" data-endspeed="300" data-endeasing="Power1.easeIn" style="color:#182035">Know More</a>

				</li>
				<li data-transition="zoomout" data-masterspeed="1300">

					<!-- MAIN IMAGE -->
					<img src="uploads/images/slides/3/bg.jpg"  alt="bg"  data-bgfit="cover" data-bgposition="center center" data-bgrepeat="no-repeat">

					<!-- LAYER NR. 1 -->
					<div class="tp-caption slider-title sfr" data-x="15" data-y="top" data-voffset="130" data-speed="800" data-start="700" data-easing="Back.easeInOut" data-endspeed="300" style="color:#d4deed">Feel free with Jets</div>

					<!-- LAYER NR. 2 -->
					<div class="tp-caption slider-sub-title sfl" data-x="15" data-y="center" data-speed="1000" data-start="800" data-easing="Back.easeInOut" data-endspeed="300" style="color:#ecc5a8">Here you will find everything <br /> you need for you</div>

					<!-- LAYER NR. 3 -->
					<div class="tp-caption sfr btn btn-big" data-x="15" data-y="bottom" data-voffset="-130" data-speed="800" data-start="900" data-easing="Power3.easeInOut" data-endspeed="300" style="color:#1a3e83">Read More</div>

				</li>
			</ul>
			<div class="tp-bannertimer tp-bottom"></div>
		</div>
	</div><!-- .page-slider-wrap -->

	<div id="page-content" role="main">
		<div class="container">

			<!-- CONTENT -->
			<div id="content">
				<div class="container-out">

					<div class="title title-section">
						<h2>Enjoy with new features</h2>
						<p>In facilisis eget nisi nec consectetur. Maecenas laoreet tellus varius, aliquet justo non, interdum metus.</p>
						<span class="sticker">
							<i class="icon fa fa-cogs"></i>
						</span>
					</div><!-- .title.title-section -->

					<div class="row">
						<div class="col-sm-4" data-animate="bounceIn">

							<div class="iconbox iconbox-style3 iconbox-list">
								<div class="iconbox-heading">
									<div class="icon">
										<i class="fa fa-building"></i>
									</div>
								</div><!-- .iconbox-heading -->
								<div class="iconbox-content">
									<div class="title">
										<h5>Over 200+ icons from Awesome and Icomoon fonts</h5>
									</div>
									<div class="text">
										<p>Netus class duis placerat duis dolor, velit varius dolor ac</p>

									</div>
								</div><!-- .iconbox-content -->
							</div><!-- .iconbox -->

						</div><!-- .col-sm-4 -->
						<div class="col-sm-4" data-animate="bounceIn">

							<div class="iconbox iconbox-style3 iconbox-list">
								<div class="iconbox-heading">
									<div class="icon">
										<i>B</i>
									</div>
								</div><!-- .iconbox-heading -->
								<div class="iconbox-content">
									<div class="title">
										<h5>New Bootstrap 3.0</h5>
									</div>
									<div class="text">
										<p>Facilisis netus ad litora sem et, feugiat consectetur posuere tellus</p>

									</div>
								</div><!-- .iconbox-content -->
							</div><!-- .iconbox -->

						</div><!-- .col-sm-4 -->
						<div class="col-sm-4" data-animate="bounceIn">

							<div class="iconbox iconbox-style3 iconbox-list">
								<div class="iconbox-heading">
									<div class="icon">
										<i class="icomoon-droplet"></i>
									</div>
								</div><!-- .iconbox-heading -->
								<div class="iconbox-content">
									<div class="title">
										<h5>Multiple color schemes</h5>
									</div>
									<div class="text">
										<p>Condimentum ut felis at sem morbi, sed praesent maecenas ultrices</p>

									</div>
								</div><!-- .iconbox-content -->
							</div><!-- .iconbox -->

						</div><!-- .col-sm-4 -->
					</div><!-- .row -->
					<div class="push"></div>
					<div class="row">
						<div class="col-sm-4" data-animate="bounceIn">

							<div class="iconbox iconbox-style3 iconbox-list">
								<div class="iconbox-heading">
									<div class="icon">
										<i class="icomoon-stack"></i>
									</div>
								</div><!-- .iconbox-heading -->
								<div class="iconbox-content">
									<div class="title">
										<h5>Flexible page structure</h5>
									</div>
									<div class="text">
										<p>Dictum malesuada congue nullam ut adipiscing, luctus proin libero blandit</p>

									</div>
								</div><!-- .iconbox-content -->
							</div><!-- .iconbox -->

						</div><!-- .col-sm-4 -->
						<div class="col-sm-4" data-animate="bounceIn">

							<div class="iconbox iconbox-style3 iconbox-list">
								<div class="iconbox-heading">
									<div class="icon">
										<i class="icomoon-code"></i>
									</div>
								</div><!-- .iconbox-heading -->
								<div class="iconbox-content">
									<div class="title">
										<h5>Clean code</h5>
									</div>
									<div class="text">
										<p>Accumsan venenatis condimentum praesent fringilla ipsum, consectetur vel placerat massa</p>

									</div>
								</div><!-- .iconbox-content -->
							</div><!-- .iconbox -->

						</div><!-- .col-sm-4 -->
						<div class="col-sm-4" data-animate="bounceIn">

							<div class="iconbox iconbox-style3 iconbox-list">
								<div class="iconbox-heading">
									<div class="icon">
										<i class="icomoon-support"></i>
									</div>
								</div><!-- .iconbox-heading -->
								<div class="iconbox-content">
									<div class="title">
										<h5>Free updates and support</h5>
									</div>
									<div class="text">
										<p>Vulputate cras ultrices morbi curabitur etiam, aenean interdum quisque metus</p>

									</div>
								</div><!-- .iconbox-content -->
							</div><!-- .iconbox -->

						</div><!-- .col-sm-4 -->
					</div><!-- .row -->
					<hr  class="devider-margin-big" />
					<div class="thumbnail" data-animate="rollIn">
						<img src="uploads/images/macbook-preview.png" alt="Macbook-preview">
					</div>
				</div><!-- .container-out -->
				<div class="container-out container-image" style="background-image:url(uploads/images/page/sections/section.jpg)" >

					<div class="title title-section">
						<h2>Our beautiful projects</h2>
						<p>Nulla facilisi. Fusce bibendum dui eu volutpat suscipit.</p>
						<span class="sticker">
							<i class="icon icomoon-quill"></i>
						</span>
					</div><!-- .title.title-section -->

					<div data-animate="slideInLeft">
						<div class="carousel-wrap">
							<ul class="carousel-nav">
								<li><a href="#" class="btn btn-icon-prev prev"></a></li>
								<li><a href="#" class="btn btn-icon-next next"></a></li>
							</ul><!-- .carousel-nav -->
							<div class="projects carousel" data-visible="3">
								<article class="project project-default photography">
									<div class="project-heading">
										<div class="thumbnail">
											<img src="uploads/images/content/image_M.jpg" alt="Image">
										</div>
										<ul class="project-action">
											<li><a class="lightbox btn btn-icon-view" href="uploads/images/content/image.jpg" data-fancybox-title="<h4>Aenean auctor</h4><p>Suspendisse eget condimentum elit. Vestibulum dignissim cursus pulvinar. Suspendisse tempus eget enim nec euismod. Ut pharetra justo sed adipiscing pretium.</p><p class='text-right'><a href='portfolio-single.html' class='btn'>View project</a></p>" data-fancybox-group="portfolio"></a></li>
											<li><a class="link btn btn-icon-link" href="portfolio-single.html"></a></li>
										</ul>
									</div><!-- .project-heading -->
									<div class="project-content">

										<div class="title">
											<h2 class="h5"><a href="portfolio-single.html">Aenean auctor</a></h2>
											<p class="meta">
												<span class="meta-like">58</span>
												<span class="meta-date">2 June</span>
												<span class="meta-comments">34</span>
											</p><!-- .meta -->
										</div><!-- .title -->

									</div><!-- .project-content -->
								</article><!-- .project -->
								<article class="project project-default illustration web animation">
									<div class="project-heading">
										<div class="thumbnail">
											<img src="uploads/images/content/image_M.jpg" alt="Image">
										</div>
										<ul class="project-action">
											<li><a class="lightbox btn btn-icon-view" href="uploads/images/content/image.jpg" data-fancybox-title="<h4>Aenean</h4><p> Maecenas dapibus euismod nunc vel condimentum. Suspendisse dapibus fermentum tempor.</p><p class='text-right'><a href='portfolio-single.html' class='btn'>View project</a></p>" data-fancybox-group="portfolio"></a></li>
											<li><a class="link btn btn-icon-link" href="portfolio-single.html"></a></li>
										</ul>
									</div><!-- .project-heading -->
									<div class="project-content">

										<div class="title">
											<h2 class="h5"><a href="portfolio-single.html">Aenean</a></h2>
											<p class="meta">
												<span class="meta-like">11</span>
												<span class="meta-date">14 June</span>
												<span class="meta-comments">8</span>
											</p><!-- .meta -->
										</div><!-- .title -->

									</div><!-- .project-content -->
								</article><!-- .project -->
								<article class="project project-default design">
									<div class="project-heading">
										<div class="thumbnail">
											<img src="uploads/images/content/image_M.jpg" alt="Image">
										</div>
										<ul class="project-action">
											<li><a class="lightbox btn btn-icon-view" href="uploads/images/content/image.jpg" data-fancybox-title="<h4>Vestibulum tristique</h4><p>Fusce eget condimentum quam. Vestibulum nec sapien odio. Etiam vel neque et tortor molestie vehicula ornare mollis tortor. Quisque in scelerisque diam.</p><p class='text-right'><a href='portfolio-single.html' class='btn'>View project</a></p>" data-fancybox-group="portfolio"></a></li>
											<li><a class="link btn btn-icon-link" href="portfolio-single.html"></a></li>
										</ul>
									</div><!-- .project-heading -->
									<div class="project-content">

										<div class="title">
											<h2 class="h5"><a href="portfolio-single.html">Vestibulum tristique</a></h2>
											<p class="meta">
												<span class="meta-like">4</span>
												<span class="meta-date">17 July</span>
												<span class="meta-comments">22</span>
											</p><!-- .meta -->
										</div><!-- .title -->

									</div><!-- .project-content -->
								</article><!-- .project -->
								<article class="project project-default design web">
									<div class="project-heading">
										<div class="thumbnail">
											<img src="uploads/images/content/image_M.jpg" alt="Image">
										</div>
										<ul class="project-action">
											<li><a class="lightbox btn btn-icon-view" href="uploads/images/content/image.jpg" data-fancybox-title="<h4>Ut quam dolor</h4><p>Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Praesent et facilisis diam. Suspendisse potenti.</p><p class='text-right'><a href='portfolio-single.html' class='btn'>View project</a></p>" data-fancybox-group="portfolio"></a></li>
											<li><a class="link btn btn-icon-link" href="portfolio-single.html"></a></li>
										</ul>
									</div><!-- .project-heading -->
									<div class="project-content">

										<div class="title">
											<h2 class="h5"><a href="portfolio-single.html">Ut quam dolor</a></h2>
											<p class="meta">
												<span class="meta-like">63</span>
												<span class="meta-date">21 July</span>
												<span class="meta-comments">14</span>
											</p><!-- .meta -->
										</div><!-- .title -->

									</div><!-- .project-content -->
								</article><!-- .project -->
								<article class="project project-default illustration design animation">
									<div class="project-heading">
										<div class="thumbnail">
											<img src="uploads/images/content/image_M.jpg" alt="Image">
										</div>
										<ul class="project-action">
											<li><a class="lightbox btn btn-icon-view" href="uploads/images/content/image.jpg" data-fancybox-title="<h4>Etiam pharetra interdum</h4><p>Phasellus quis elit libero. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin justo mauris, vestibulum eget turpis nec, cursus tempor arcu.</p><p class='text-right'><a href='portfolio-single.html' class='btn'>View project</a></p>" data-fancybox-group="portfolio"></a></li>
											<li><a class="link btn btn-icon-link" href="portfolio-single.html"></a></li>
										</ul>
									</div><!-- .project-heading -->
									<div class="project-content">

										<div class="title">
											<h2 class="h5"><a href="portfolio-single.html">Etiam pharetra interdum</a></h2>
											<p class="meta">
												<span class="meta-like">7</span>
												<span class="meta-date">20 Aug</span>
												<span class="meta-comments">41</span>
											</p><!-- .meta -->
										</div><!-- .title -->

									</div><!-- .project-content -->
								</article><!-- .project -->
								<article class="project project-default illustration design">
									<div class="project-heading">
										<div class="thumbnail">
											<img src="uploads/images/content/image_M.jpg" alt="Image">
										</div>
										<ul class="project-action">
											<li><a class="lightbox btn btn-icon-view" href="uploads/images/content/image.jpg" data-fancybox-title="<h4>Suspendisse</h4><p>Nam dolor felis, tristique quis posuere ac, molestie ut nulla. Sed ornare lorem ut est faucibus, a pulvinar odio dignissim. In lacinia placerat ipsum, ut aliquet justo sagittis vitae.</p><p class='text-right'><a href='portfolio-single.html' class='btn'>View project</a></p>" data-fancybox-group="portfolio"></a></li>
											<li><a class="link btn btn-icon-link" href="portfolio-single.html"></a></li>
										</ul>
									</div><!-- .project-heading -->
									<div class="project-content">

										<div class="title">
											<h2 class="h5"><a href="portfolio-single.html">Suspendisse</a></h2>
											<p class="meta">
												<span class="meta-like">21</span>
												<span class="meta-date">29 Aug</span>
												<span class="meta-comments">2</span>
											</p><!-- .meta -->
										</div><!-- .title -->

									</div><!-- .project-content -->
								</article><!-- .project -->
							</div><!-- .carousel -->
							<div class="carousel-pagi"></div>
						</div><!-- .carousel-wrap -->
					</div>

				</div><!-- .container-out -->
				<div class="container-out container-light container-no-bottom">
					<div class="row-inline-wrap">
						<div class="row row-inline">
							<div class="col-sm-6" data-animate="bounceInLeft">
								<img src="uploads/images/ipad-preview.png" alt="Ipad-preview">
							</div><!-- .col-sm-6 -->
							<div class="col-sm-6" data-animate="bounceInRight">

								<div class="title">
									<h3>You will be pleasantly surprised</h3>
								</div><!-- .title -->

								<div class="text">
									<p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.</p>
								</div><!-- .text -->

							</div><!-- .col-sm-6 -->
						</div><!-- .row -->
					</div><!-- .row-inline-wrap -->
				</div><!-- .container-out -->
				<div class="container-out">

					<div class="title title-section">
						<h2>Latest news from the blog</h2>
						<p>Integer vel lectus orci. Nam non purus at odio ultricies malesuada.</p>
						<span class="sticker">
							<i class="icon fa fa-bullhorn"></i>
						</span>
					</div><!-- .title.title-section -->

					<div data-animate="flipInY">
						<div class="carousel-wrap">
							<ul class="carousel-nav">
								<li><a href="#" class="btn btn-icon-prev prev"></a></li>
								<li><a href="#" class="btn btn-icon-next next"></a></li>
							</ul><!-- .carousel-nav -->
							<div class="carousel" data-visible="3">
								<article class="post post-latest post-type-gallery">
									<div class="post-heading">
										<div class="thumbnail">
											<div class="slider">
												<img src="uploads/images/content/image_L.jpg" alt="Image">
												<img src="uploads/images/content/image_L.jpg" alt="Image">
												<img src="uploads/images/content/image_L.jpg" alt="Image">
											</div><!-- .slider -->
										</div><!-- .thumbnail -->
									</div><!-- .post-heading -->
									<div class="post-content">
										<div class="type"></div><!-- .type -->
										<div class="title">
											<h2 class="h4"><a href="blog-single.html">Sed ut perspiciatis unde omnis</a></h2>
											<p class="meta">
												<span class="meta-category"><a href="#">neque</a> / <a href="#">vitae</a> / <a href="#">eget</a></span>
												<span class="meta-date">19 Jan</span>
											</p>
										</div><!-- .title -->
										<div class="text">
											<p>Praesent aptent quam sem netus tempor bibendum orci, at elementum aliquam lacus ornare erat, sollicitudin lacus arcu eget porttitor egestas <a href="blog-single.html">...more...</a></p>
										</div><!-- .text -->
									</div><!-- .post-content -->
								</article><!-- .post -->
								<article class="post post-latest post-type-video">
									<div class="post-heading">

										<div class="thumbnail">
											<video style="width: 100%; height: 100%;" class="fc-media fc-video" poster="uploads/video/bubbles_animation/bubbles_animation_banner.jpg" controls><source src="uploads/video/bubbles_animation/bubbles_animation.mp4" type="video/mp4" /><source src="uploads/video/bubbles_animation/bubbles_animation.webm" type="video/webm" /><source src="uploads/video/bubbles_animation/bubbles_animation.ogv" type="video/ogv" /></video>
										</div><!-- .thumbnail -->
									</div><!-- .post-heading -->
									<div class="post-content">
										<div class="type"></div><!-- .type -->
										<div class="title">
											<h2 class="h4"><a href="blog-single.html">Adipisci velite</a></h2>
											<p class="meta">
												<span class="meta-category"><a href="#">sed</a></span>
												<span class="meta-date">3 June</span>
											</p>
										</div><!-- .title -->
										<div class="text">
											<p>Velit at libero massa praesent accumsan justo malesuada donec diam sapien, lorem dolor feugiat aptent sapien etiam cubilia orci ornare <a href="blog-single.html">...more...</a></p>
										</div><!-- .text -->
									</div><!-- .post-content -->
								</article><!-- .post -->
								<article class="post post-latest post-type-image">
									<div class="post-heading">
										<div class="thumbnail">
											<a class="link" href="blog-single.html">
												<span class="btn btn-icon-link"></span>
												<img src="uploads/images/content/image_L.jpg" alt="Image">
											</a>
										</div><!-- .thumbnail -->
									</div><!-- .post-heading -->
									<div class="post-content">
										<div class="type"></div><!-- .type -->
										<div class="title">
											<h2 class="h4"><a href="blog-single.html">Neque porro quisquam est, qui</a></h2>
											<p class="meta">
												<span class="meta-category"><a href="#">eget</a> / <a href="#">commodo</a></span>
												<span class="meta-date">24 May</span>
											</p>
										</div><!-- .title -->
										<div class="text">
											<p>Donec nostra aliquam leo felis vehicula nec ad, nec interdum nisl accumsan curabitur aliquet, nunc tristique eros tempor arcu aenean <a href="blog-single.html">...more...</a></p>
										</div><!-- .text -->
									</div><!-- .post-content -->
								</article><!-- .post -->
								<article class="post post-latest post-type-vimeo">
									<div class="post-heading">

										<div class="thumbnail">
											<iframe src="//player.vimeo.com/video/35565030" width="100%" height="100%" frameborder="0" webkitallowfullscreen mozallowfullscreen allowfullscreen></iframe>
										</div><!-- .thumbnail -->
									</div><!-- .post-heading -->
									<div class="post-content">
										<div class="type"></div><!-- .type -->
										<div class="title">
											<h2 class="h4"><a href="blog-single.html">Architecto beatae vitae</a></h2>
											<p class="meta">
												<span class="meta-category"><a href="#">vel</a> / <a href="#">diam</a> / <a href="#">vitae</a></span>
												<span class="meta-date">9 Aug</span>
											</p>
										</div><!-- .title -->
										<div class="text">
											<p>Eget condimentum per condimentum est vehicula habitasse id ad convallis est, fames ultricies euismod inceptos vel ac eleifend augue suscipit <a href="blog-single.html">...more...</a></p>
										</div><!-- .text -->
									</div><!-- .post-content -->
								</article><!-- .post -->
								<article class="post post-latest post-type-gallery">
									<div class="post-heading">
										<div class="thumbnail">
											<div class="slider">
												<img src="uploads/images/content/image_L.jpg" alt="Image">
												<img src="uploads/images/content/image_L.jpg" alt="Image">
												<img src="uploads/images/content/image_L.jpg" alt="Image">
											</div><!-- .slider -->
										</div><!-- .thumbnail -->
									</div><!-- .post-heading -->
									<div class="post-content">
										<div class="type"></div><!-- .type -->
										<div class="title">
											<h2 class="h4"><a href="blog-single.html">Quis nostrum exercitationem</a></h2>
											<p class="meta">
												<span class="meta-category"><a href="#">non</a> / <a href="#">commodo</a> / <a href="#">diam</a> / <a href="#">nulla</a></span>
												<span class="meta-date">24 Sept</span>
											</p>
										</div><!-- .title -->
										<div class="text">
											<p>Sociosqu eu est libero suscipit primis velit ipsum curabitur suscipit massa, curabitur mi semper libero turpis in mattis egestas porttitor <a href="blog-single.html">...more...</a></p>
										</div><!-- .text -->
									</div><!-- .post-content -->
								</article><!-- .post -->
								<article class="post post-latest post-type-image">
									<div class="post-heading">
										<div class="thumbnail">
											<a class="link" href="blog-single.html">
												<span class="btn btn-icon-link"></span>
												<img src="uploads/images/content/image_L.jpg" alt="Image">
											</a>
										</div><!-- .thumbnail -->
									</div><!-- .post-heading -->
									<div class="post-content">
										<div class="type"></div><!-- .type -->
										<div class="title">
											<h2 class="h4"><a href="blog-single.html">Amet, consectetur adipisicing elit</a></h2>
											<p class="meta">
												<span class="meta-category"><a href="#">dapibus</a> / <a href="#">faucibus</a></span>
												<span class="meta-date">15 Oct</span>
											</p>
										</div><!-- .title -->
										<div class="text">
											<p>Sodales suspendisse sagittis velit odio interdum vulputate donec, ipsum pulvinar sollicitudin platea ad primis, eget convallis sit eleifend fusce curabitur <a href="blog-single.html">...more...</a></p>
										</div><!-- .text -->
									</div><!-- .post-content -->
								</article><!-- .post -->
							</div><!-- .carousel -->
						</div><!-- .carousel-wrap -->
					</div>

				</div><!-- .container-out -->
				<div class="container-out container-light">

					<div class="title title-section">
						<h2>Get to know our clients</h2>
						<p>Ut pellentesque augue dui.</p>
						<span class="sticker">
							<i class="icon icomoon-earth"></i>
						</span>
					</div><!-- .title.title-section -->

					<div data-animate="slideInRight">
						<div class="carousel-wrap">
							<ul class="carousel-nav">
								<li><a href="#" class="btn btn-icon-prev prev"></a></li>
								<li><a href="#" class="btn btn-icon-next next"></a></li>
							</ul><!-- .carousel-nav -->
							<div class="clients carousel" data-visible="4">
								<div class="client">
									<img src="uploads/images/clients/client.png" alt="Client">
								</div>
								<div class="client">
									<img src="uploads/images/clients/client.png" alt="Client">
								</div>
								<div class="client">
									<img src="uploads/images/clients/client.png" alt="Client">
								</div>
								<div class="client">
									<img src="uploads/images/clients/client.png" alt="Client">
								</div>
								<div class="client">
									<img src="uploads/images/clients/client.png" alt="Client">
								</div>
							</div><!-- .carousel -->
						</div><!-- .carousel-wrap -->
					</div>

				</div><!-- .container-out -->
				<div class="container-out container-image" style="background-image:url(uploads/images/page/sections/section.jpg)">

					<div class="title title-section">
						<h2>What people say about us?</h2>
						<p>Vestibulum ante ipsum primis in faucibus orci luctus et ultrices.</p>
						<span class="sticker">
							<i class="icon fa fa-thumbs-o-up"></i>
						</span>
					</div><!-- .title.title-section -->

					<div data-animate="bounceIn">
						<div class="testimonial-wrap">
							<div class="testimonial-outer">
								<ul class="testimonial" data-auto="true">
									<li>
										<div class="testimonial-content">

											<div class="text">
												<p>Erat himenaeos curabitur praesent maecenas phasellus lectus taciti in fermentum hendrerit, habitant ipsum morbi senectus purus feugiat nunc nec mollis</p>
											</div>

										</div><!-- .testimonial-content  -->
										<div class="testimonial-heading">

											<div class="title">
												<h4>John Doe</h4>
												<p class="position">Microsoft</p>
											</div>

										</div><!-- .testimonial-heading  -->
									</li>
									<li>
										<div class="testimonial-content">

											<div class="text">
												<p>Tellus vivamus enim senectus justo donec porta ante, eleifend curabitur consectetur elit augue potenti, et commodo accumsan volutpat dictum elit</p>
											</div>

										</div><!-- .testimonial-content  -->
										<div class="testimonial-heading">

											<div class="title">
												<h4>Mary Smith</h4>
												<p class="position">themeforest</p>
											</div>

										</div><!-- .testimonial-heading  -->
									</li>
									<li>
										<div class="testimonial-content">

											<div class="text">
												<p>Eu venenatis auctor vivamus auctor dictum mattis blandit, habitant urna est elementum habitant ullamcorper, euismod sem quisque dolor pharetra imperdiet</p>
											</div>

										</div><!-- .testimonial-content  -->
										<div class="testimonial-heading">

											<div class="title">
												<h4>Daniel Anderson</h4>
												<p class="position">apple</p>
											</div>

										</div><!-- .testimonial-heading  -->
									</li>
									<li>
										<div class="testimonial-content">

											<div class="text">
												<p>Nec urna curabitur suscipit elit donec vitae etiam justo lorem iaculis, integer sed suspendisse semper etiam pellentesque ultrices varius auctor</p>
											</div>

										</div><!-- .testimonial-content  -->
										<div class="testimonial-heading">

											<div class="title">
												<h4>Jane Johnson</h4>
												<p class="position">google</p>
											</div>

										</div><!-- .testimonial-heading  -->
									</li>
								</ul><!-- .testimonial -->
							</div><!-- .testimonial-outer -->
							<div class="testimonial-pagi"></div>
						</div><!-- .testimonial-wrap -->
					</div>

				</div><!-- .container-out -->
			</div><!-- #content -->

		</div><!-- .container -->
	</div><!-- #page-content -->

	<footer id="footer">
		<div class="container">
			<div class="row row-inline">
				<div class="col-sm-6">

					<div class="title title-main">
						<h5>Newsletter</h5>
					</div>
					<div class="text">
						<p>Keep up on our always evolving product features and technology. Enter your e-mail and subscribe to our newsletter.</p>
					</div>

				</div><!-- .col-sm-6 -->
				<div class="col-sm-6">

					<form action="php/newsletter.php" method="POST" class="form-validate" data-submit="ajax">
						<button type="submit" class="btn btn-big btn-icon-newsletter"></button>
						<div class="form-field">
							<div class="placeholder">
								<label for="subscribeemail">email...</label>
								<input class="form-control" type="email" maxlength="100" name="subscribeemail" id="subscribeemail" required />
							</div>
						</div>
					</form>

				</div><!-- .col-sm-6 -->
			</div><!-- .row-->

			<hr class="devider-heavy" />
			<div class="row">
				<div class="col-sm-3">

					<div class="widget">
						<div class="widget-heading">

							<div class="title title-main">
								<a href="index.html" class="logo">
									<img src="img/logo-white.png" alt="Jets">
								</a>
							</div>

						</div><!-- .widget-heading -->
						<div class="widget-content">

							<div class="text">
								<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur augue nunc, tempus id imperdiet eu.</p>
								<p>Mauris pulvinar est in quam dapibus a bibendum. Lorem ipsum dolor sit amet, consectetur Lorem ipsum dolor. </p>
							</div>

						</div><!-- .widget-content -->
					</div><!-- .widget -->

				</div><!-- .col-sm-3 -->
				<div class="col-sm-3">

					<div class="widget">
						<div class="widget-heading">

							<div class="title title-main">
								<h5>Latest from Blog</h5>
							</div>

						</div><!-- .widget-heading -->
						<div class="widget-content">

							<section class="posts">
								<article class="post post-mini post-type-text">
									<div class="post-heading">
										<div class="thumbnail">
											<a class="link" href="blog-single.html">
												<span class="btn btn-icon-link"></span>
												<img src="uploads/images/content/image_SQ.jpg" alt="Image">
											</a>
										</div><!-- .thumbnail -->
									</div><!-- .post-heading -->
									<div class="post-content">
										<div class="title">
											<h2 class="h5"><a href="blog-single.html">Sed ut perspiciatis unde omnis iste</a></h2>
										</div><!-- .title -->
									</div><!-- .post-content -->
								</article><!-- .post -->
								<article class="post post-mini post-type-music">
									<div class="post-heading">
										<div class="thumbnail">
											<a class="link" href="blog-single.html">
												<span class="btn btn-icon-link"></span>
												<img src="uploads/images/content/image_SQ.jpg" alt="Image">
											</a>
										</div><!-- .thumbnail -->
									</div><!-- .post-heading -->
									<div class="post-content">
										<div class="title">
											<h2 class="h5"><a href="blog-single.html">Consequuntur magni dolores</a></h2>
										</div><!-- .title -->
									</div><!-- .post-content -->
								</article><!-- .post -->
							</section><!-- .posts -->

						</div><!-- .widget-content -->
					</div><!-- .widget -->

				</div><!-- .col-sm-3 -->
				<div class="col-sm-3">

					<div class="widget">
						<div class="widget-heading">

							<div class="title title-main">
								<h5>Popular tags</h5>
							</div><!-- .title -->

						</div><!-- .widget-heading -->
						<div class="widget-content">

							<div class="tags">
								<p><a href="#" rel="tag">quam</a><a href="#" rel="tag">porta</a><a href="#" rel="tag">pretium</a><a href="#" rel="tag">ultricies</a><a href="#" rel="tag">nulla</a><a href="#" rel="tag">scelerisque</a><a href="#" rel="tag">nisi</a><a href="#" rel="tag">uspendisse</a><a href="#" rel="tag">massa</a><a href="#" rel="tag">libero</a><a href="#" rel="tag">auctor </a><a href="#" rel="tag">arcu</a><a href="#" rel="tag">enim</a><a href="#" rel="tag">varius</a><a href="#" rel="tag">dui</a><a href="#" rel="tag">imperdiet</a><a href="#" rel="tag">adipiscing</a><a href="#" rel="tag">rhoncus</a><a href="#" rel="tag">fermentum</a><a href="#" rel="tag">ligula</a><a href="#" rel="tag">sagittis</a><a href="#" rel="tag">nunc</a><a href="#" rel="tag">orci</a></p>
							</div><!-- .tags -->

						</div><!-- .widget-content -->
					</div><!-- .widget -->

				</div><!-- .col-sm-3 -->
				<div class="col-sm-3">

					<div class="widget">
						<div class="widget-heading">
							<div class="title title-main">
								<h5>Photostream</h5>
							</div>
						</div><!-- .widget-heading -->
						<div class="widget-content">
							<ul id="flickr" data-id="41389393@N02" class="photo-stream"></ul>
						</div><!-- .widget-content -->
					</div><!-- .widget -->

				</div><!-- .col-sm-3 -->
			</div><!-- .row-->
			<hr class="devider-heavy" />
			<ul class="nav text-center">
				<li><a href="index.html">Home</a></li>
				<li><a href="#">Features</a></li>
				<li><a href="#">Shortcodes</a></li>
				<li><a href="#">Portfolio</a></li>
				<li><a href="#">Pages</a></li>
				<li><a href="#">Blog</a></li>
				<li><a href="#">Contact</a></li>
			</ul>
			<hr class="devider-heavy" />
			<div class="row-inline-wrap">
				<div class="row row-inline">
					<div class="col-md-7">

						<ul class="touch">
							<li><i class="fa icomoon-location"></i><p>322 Victoria Street<br />Darlinghurst NSW 2010</p></li>
							<li><i class="fa fa-phone"></i><p>1800-2233-4455<br />1800-6677-8899</p></li>
							<li><i class="fa fa-envelope"></i><p><a href="mailto:victoria@yoursite.com">victoria@yoursite.com</a><br /><a href="mailto:macdonald@yoursite.com">macdonald@yoursite.com</a></p></li>
						</ul>

					</div><!-- .col-md-7 -->
					<div class="col-md-5">

						<ul class="social">
							<li><a href="#" class="rss"></a></li>
							<li><a href="#" class="google"></a></li>
							<li><a href="#" class="vimeo"></a></li>
							<li><a href="#" class="youtube"></a></li>
							<li><a href="#" class="facebook"></a></li>
							<li><a href="#" class="twitter"></a></li>
						</ul>

					</div><!-- .col-md-5 -->
				</div><!-- .row -->
			</div><!-- .row-inline-wrap -->
		</div><!-- .container -->
		<div class="credits">JETS © 2013<span>|</span><a href="#">Terms</a><span>|</span><a href="#">Legal Notice</a></div>
	</footer>

	<!-- Login/Register Modal -->
	<div id="login-register" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="false">
		<div class="modal-dialog container">
			<div class="row">

				<div class="modal-bg" data-dismiss="modal"></div>

				<div class="col-sm-6">

					<div class="modal-body">
						<div class="modal-content">
							<a href="#" type="button" class="close btn btn-dark btn-icon-close" data-dismiss="modal" aria-hidden="true"></a>
							<div class="tab" data-animation="slide">
								<ul class="tab-heading">
									<li class="current"><h6><a href="#">Log in</a></h6></li>
									<li><h6><a href="#">Register</a></h6></li>
								</ul><!-- .tab-heading -->
								<div class="tab-content">
									<div class="current">

										<form action="php/your-action.php" method="POST" class="form-validate" id="login">
											<div class="form-field">
												<div class="row">
													<label for="login-username" class="col-sm-3">Username<span class="require">*</span></label>
													<div class="col-sm-9">
														<input class="form-control" type="text" name="login-username" id="login-username" required />
													</div>
												</div>
											</div><!-- .form-field -->
											<div class="form-field">
												<div class="row">
													<label for="login-password" class="col-sm-3">Password<span class="require">*</span></label>
													<div class="col-sm-9">
														<input class="form-control" type="password" name="login-password" id="login-password" required />
													</div>
												</div>
											</div><!-- .form-field -->
											<div class="form-field">
												<div class="row">
													<div class="col-sm-offset-3 col-sm-9">
														<input type="checkbox" name="login-remember" id="login-remember">
														<label for="login-remember">Remember me</label>
													</div>
												</div>
											</div><!-- .form-field -->
											<div class="form-field text-right">
												<div class="form-group">
													Forgot your password? <a href="#" title="Password Lost and Found" class="recovery-open">Reset it here</a>
												</div>
												<div class="form-group">
													<input type="submit" value="Log in" class="btn">
												</div>
											</div><!-- .form-field -->
										</form>
										<form action="php/your-action.php" method="POST" class="form-validate clear" id="recovery">
											<hr>
											<div class="title">
												<a href="#" class="recovery-close"><i class="fa fa-times"></i></a>
												<h4>Reset your password</h4>
											</div>
											<div class="text">
												<p>Enter your email address below and we'll send a special reset password link to your inbox.</p>
											</div>
											<div class="form-field">
												<div class="row">
													<label for="recovery-email" class="col-sm-3">Email<span class="require">*</span></label>
													<div class="col-sm-9">
														<input class="form-control" type="email" name="recovery-email" id="recovery-email" required />
													</div>
												</div>
											</div><!-- .form-field -->
											<div class="form-field text-right">
												<input type="submit" value="Send Recovery Email" class="btn">
											</div><!-- .form-field -->
										</form>
									</div>
									<div>
										<form action="php/your-action.php" method="POST" class="form-validate" id="register">
											<div class="form-field">
												<div class="row">
													<label for="register-username" class="col-sm-3">Username<span class="require">*</span></label>
													<div class="col-sm-9">
														<input class="form-control" type="text" name="register-username" id="register-username" required />
													</div>
												</div>
											</div><!-- .form-field -->
											<div class="form-field">
												<div class="row">
													<label for="register-password" class="col-sm-3">Password <span class="require">*</span></label>
													<div class="col-sm-9">
														<input class="form-control" type="password" name="register-password" minlength="6" id="register-password" required />
														<p class="form-desc">6 or more characters</p>
													</div>
												</div>
											</div><!-- .form-field -->
											<div class="form-field">
												<div class="row">
													<label for="register-confirm" class="col-sm-3">Confirm <span class="require">*</span></label>
													<div class="col-sm-9">
														<input class="form-control" type="password" name="register-confirm" id="register-confirm" minlength="6" placeholder="Retype password" required />
													</div>
												</div>
											</div><!-- .form-field -->
											<div class="form-field">
												<div class="row">
													<label for="register-date" class="col-sm-3">Birth Date <span class="require">*</span></label>
													<div class="col-sm-9">
														<div class="form-group">
															<select name="register-month" id="register-date" required>
																<option value="">Month</option>
																<option value="January">January</option>
																<option value="February">February</option>
																<option value="Mars">Mars</option>
																<option value="April">April</option>
																<option value="May">May</option>
																<option value="June">June</option>
																<option value="July">July</option>
																<option value="September">September</option>
																<option value="October">October</option>
																<option value="November">November</option>
																<option value="December">December</option>
															</select>
														</div><!-- .form-group -->
														<div class="form-group-separator">/</div>
														<div class="form-group">
															<select name="register-day" required>
																<option value="">Day</option>
																<option value="1">1</option>
																<option value="2">2</option>
																<option value="3">3</option>
																<option value="4">4</option>
																<option value="5">5</option>
																<option value="6">6</option>
																<option value="7">7</option>
																<option value="8">8</option>
																<option value="9">9</option>
																<option value="10">10</option>
																<option value="11">11</option>
																<option value="12">12</option>
																<option value="13">13</option>
																<option value="14">14</option>
																<option value="15">15</option>
																<option value="16">16</option>
																<option value="17">17</option>
																<option value="18">18</option>
																<option value="19">19</option>
																<option value="20">20</option>
																<option value="21">21</option>
																<option value="22">22</option>
																<option value="23">23</option>
																<option value="24">24</option>
																<option value="25">25</option>
																<option value="26">26</option>
																<option value="27">27</option>
																<option value="28">28</option>
																<option value="29">29</option>
																<option value="30">30</option>
																<option value="31">31</option>
															</select>
														</div><!-- .form-group -->
														<div class="form-group-separator">/</div>
														<div class="form-group">
															<select name="register-year" required>
																<option value="">Year</option>
																<option value="2013">2013</option>
																<option value="2012">2012</option>
																<option value="2011">2011</option>
																<option value="2010">2010</option>
																<option value="2009">2009</option>
																<option value="2008">2008</option>
																<option value="2007">2007</option>
																<option value="2006">2006</option>
																<option value="2005">2005</option>
																<option value="2004">2004</option>
																<option value="2003">2003</option>
																<option value="2002">2002</option>
																<option value="2001">2001</option>
																<option value="2000">2000</option>
																<option value="1999">1999</option>
																<option value="1998">1998</option>
																<option value="1997">1997</option>
																<option value="1996">1996</option>
																<option value="1995">1995</option>
																<option value="1994">1994</option>
																<option value="1993">1993</option>
																<option value="1992">1992</option>
																<option value="1991">1991</option>
																<option value="1990">1990</option>
																<option value="1989">1989</option>
																<option value="1988">1988</option>
																<option value="1987">1987</option>
																<option value="1986">1986</option>
																<option value="1985">1985</option>
																<option value="1984">1984</option>
																<option value="1983">1983</option>
																<option value="1982">1982</option>
																<option value="1981">1981</option>
																<option value="1980">1980</option>
																<option value="1979">1979</option>
																<option value="1978">1978</option>
																<option value="1977">1977</option>
																<option value="1976">1976</option>
																<option value="1975">1975</option>
																<option value="1974">1974</option>
																<option value="1973">1973</option>
																<option value="1972">1972</option>
																<option value="1971">1971</option>
																<option value="1970">1970</option>
																<option value="1969">1969</option>
																<option value="1968">1968</option>
																<option value="1967">1967</option>
																<option value="1966">1966</option>
																<option value="1965">1965</option>
																<option value="1964">1964</option>
																<option value="1963">1963</option>
																<option value="1962">1962</option>
																<option value="1961">1961</option>
																<option value="1960">1960</option>
																<option value="1959">1959</option>
																<option value="1958">1958</option>
																<option value="1957">1957</option>
																<option value="1956">1956</option>
																<option value="1955">1955</option>
																<option value="1954">1954</option>
																<option value="1953">1953</option>
																<option value="1952">1952</option>
																<option value="1951">1951</option>
																<option value="1950">1950</option>
																<option value="1949">1949</option>
																<option value="1948">1948</option>
																<option value="1947">1947</option>
																<option value="1946">1946</option>
																<option value="1945">1945</option>
																<option value="1944">1944</option>
																<option value="1943">1943</option>
																<option value="1942">1942</option>
																<option value="1941">1941</option>
																<option value="1940">1940</option>
															</select>
														</div><!-- .form-group -->
													</div>
												</div>
											</div><!-- .form-field -->
											<div class="form-field">
												<div class="row">
													<div class="col-sm-offset-3 col-sm-9">
														<input type="checkbox" name="register-remember" id="register-remember">
														<label for="register-remember">Remember me</label>
													</div>
												</div>
											</div><!-- .form-field -->
											<div class="form-field text-right">
												<input type="submit" value="Register" class="btn">
											</div><!-- .form-field -->
										</form>
									</div>
								</div><!-- .tab-content -->
							</div><!-- .tab -->
						</div><!-- .modal-content -->
					</div><!-- .modal-body -->

				</div><!-- .col-sm-6 -->
			</div><!-- .row -->
		</div><!-- .modal-dialog -->
	</div><!-- #login-register-modal -->

	<a class="btn btn-icon-top" id="toTop" href="#"></a>

	<!-- jQuery & Helper library -->
	<script type="text/javascript" src="js/library/jquery/jquery-1.11.0.min.js"></script>
	<script type="text/javascript" src="js/library/jquery/jquery-ui-1.10.4.custom.min.js"></script>

	<!-- Retina js -->
	<script type="text/javascript" src="js/library/retina/retina.min.js"></script>

	<!-- FancyBox -->
	<script type="text/javascript" src="js/library/fancybox/jquery.fancybox.pack.js?v=2.1.5"></script>

	<!-- Bootstrap js -->
	<script type="text/javascript" src="js/library/bootstrap/bootstrap.min.js"></script>

	<!-- Validate -->
	<script type="text/javascript" src="js/library/validate/jquery.validate.min.js"></script>

	<!-- FlickrFeed  -->
	<script type="text/javascript" src="js/library/jFlickrFeed/jflickrfeed.min.js"></script>

	<!-- carouFredSel -->
	<script type="text/javascript" src="js/library/carouFredSel/jquery.carouFredSel-6.2.1-packed.js"></script>

	<!-- Mediaelementjs -->
	<script type="text/javascript" src="js/library/mediaelementjs/mediaelement-and-player.min.js"></script>

	<!-- SLIDER REVOLUTION 4.x SCRIPTS  -->
	<script type="text/javascript" src="js/library/slider-revolution/js/jquery.themepunch.plugins.min.js"></script>
	<script type="text/javascript" src="js/library/slider-revolution/js/jquery.themepunch.revolution.min.js"></script>
	<script type="text/javascript" src="js/slider.min.js"></script>

	<!-- Main theme javaScript file -->
	<script type="text/javascript" src="js/theme.min.js"></script>
</body>
</html>